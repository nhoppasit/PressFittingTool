using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace Press_Fit_Pro
{

    public class RunPressFitClass : IDisposable
    {
        #region Dispose

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here. 
                //
                DoDisposed();
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

        private void DoDisposed()
        {
            //Board : graphic model
            foreach (ConnectorEntityClass t in Board.ConnectorEntities)
            {
                t.Dispose();
            }
            Board.ConnectorEntities.Clear();
        }

        #endregion

        #region Members

        enum LoopStateEnumeration { WaitTwoHandSW, Initialization, Run, Finialize, Cancel };

        static public LoadCellIndicatorClass Indicator;
        public ControlClass SWControl;

        public BoardInfo Info;
        static public BoardModelClass Board;
        static public PlotModelClass Plotter;

        //Reference
        private PictureBox boardCanvas;
        private PictureBox graphCanvas;
        private frmMain Owner;

        //Status
        public bool Running = false;
        public bool DoneRunning = false;
        public bool Saved = false;

        #endregion

        #region Properties

        public string ServoComPortName { get; set; }
        public string IndicatorComPortName { get; set; }

        #endregion

        #region Constructor/Deconstructor

        public RunPressFitClass(ref frmMain owner, ref PictureBox board, ref PictureBox graph, BoardInfo info)
        {
            this.Owner = owner;
            //
            //Indicator
            IndicatorComPortName = AppConfig.IndicatorPortName;
            Indicator = new LoadCellIndicatorClass();
            //
            //Switch control
            SWControl = new ControlClass();
            //
            //Servo driver
            ServoComPortName = AppConfig.ServoPortName;
            //
            //Reference
            this.boardCanvas = board;
            this.graphCanvas = graph;
            //
            //Graphic model
            this.Info = info;
            if (Board == null) Board = new BoardModelClass(ref this.boardCanvas, info);
            else Board.UpdateBoardInfo(info);
            //
            //Plotter
            if (Plotter == null) Plotter = new PlotModelClass(ref this.graphCanvas, info);
            else Plotter.Info = info;
        }

        ~RunPressFitClass()
        {
            Dispose();
        }

        #endregion

        #region Pression

        //Control
        static public long Nominator = Properties.Settings.Default.Nominator;
        static public long Denominator = Properties.Settings.Default.Denominator;
        static public double MechanicsRatio = -Nominator / Denominator;
        static public float GearRatio = Properties.Settings.Default.GearRatio;
        static double offsetHeight;
        static double posHeight;
        static double offsetWeight;
        static double weight;
        private string currentHisFile = "";

        public void Start(string hisFile)
        {
            try
            {
                //Start interfacing robot
                UI.UpdateFormEnable(false);

                currentHisFile = hisFile;
                UI.Log("History file: " + currentHisFile, 0);

                UI.Log("Connecting control unit...", 0);
                //SWControl.Connect("COM5");
                //string ssw = SWControl.ReadHand();
                UI.Log("Done Connecting control unit.", 0);

                UI.Log("Connecting indicator...", 0);
                //Indicator.Connect(IndicatorComPortName);
                //string sweight = Indicator.ReadDouble().ToString();
                UI.Log("Done connecting indicator.", 0);

                UI.Log("Connecting servo driver...", 0);
                //ConnectServo();
                UI.Log("Done connecting servo driver.", 0);

                UI.Log("Clearing plotter...", 0);
                Plotter.Clear();

                UI.Log("Done clearing plotter.", 0);
                System.Threading.Thread.Sleep(100);

                /* ---------------------------------------
                 * Start thread!!!
                 * ---------------------------------------*/
                //StartPress();
                StartPressDemo();
            }
            catch (Exception ex)
            {
                Owner.Enabled = true;
                Log.AppendText(ex.Message);
                MessageBox.Show("Error : " + ex.Message, "RUN");
                UI.Log("Error : " + ex.Message, 0);
                UI.UpdateFormEnable(true);
            }
        }

        const char STX = (char)0x02;
        const char ETX = (char)0x03;

        private static char Axis = '1';
        private static string Ctrl = "00";
        private static bool conMain = false;

        public static bool Servo_Responding = false;
        public static string ckTest = "";
        public static int countTest = 0;

        public System.Threading.Thread pressThread;
        public static System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();

        public enum SERVOSTAGE
        {
            _00_SERVO_OFF,
            _10_SERVO_ON,
            _20_SERVO_RUN,
            _30_SERVO_READY,
            _40_SERVO_ALARM,
            _50_SERVO_EMERGENCY,
        }
        public static SERVOSTAGE curServoStage = SERVOSTAGE._00_SERVO_OFF;

        public enum PROCESSSTAGE
        {
            _00_STOP,
            _10_START,
        }
        public static PROCESSSTAGE curProcessStage = PROCESSSTAGE._00_STOP;

        public void ConnectServo()
        {
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Close();
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = System.IO.Ports.Parity.Even;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                //serialPort1.Encoding = System.Text.ASCIIEncoding.Default;
                serialPort1.Encoding = System.Text.Encoding.GetEncoding(28605);
                serialPort1.ReadTimeout = 1000;
                serialPort1.WriteTimeout = 1000;
                serialPort1.Open();
            }
            catch
            {
                throw;
            }
        }

        public void InitPress()
        {
            //curServoStage == SERVOSTAGE._10_SERVO_ON;
            conMain = true;
            pressThread = new System.Threading.Thread(PressFlow);
            pressThread.Start();
        }

        public void StartPress()
        {
            //long pos,int velo,int dir
            //curProcessStage = PROCESSSTAGE._10_START;
            conMain = true;
            pressThread = new System.Threading.Thread(PressFlow);
            pressThread.Start();
        }

        public void StartPressDemo()
        {
            //long pos,int velo,int dir
            //curProcessStage = PROCESSSTAGE._10_START;
            conMain = true;
            pressThread = new System.Threading.Thread(PressFlowDemo);
            pressThread.Start();
        }

        public void StopPress()
        {
            conMain = false;
            //pressThread.Join();
            readAlarm();
            resetAlarm();
        }

        public void ContinuePress()
        {
            //pressThread = new System.Threading.Thread(PressFlow);
            countTest = 0;
            //pressThread.Join();
            curProcessStage = PROCESSSTAGE._10_START;
            pressThread = new System.Threading.Thread(PressFlow);
        }

        public void PressFlow()
        {
            countTest = 1;
            conMain = true;

            while (conMain)
            {
                UI.Log("Start Process" + countTest.ToString(), 0);

                if (!Servo_Init("CCW", 150, 250))
                {
                    goto ENDTXN;
                }
                UI.Log("1.------- Go Home Done ------------", 0);
                System.Threading.Thread.Sleep(20);

                if (!Servo_Init("CW", 40, 400))
                {
                    goto ENDTXN;
                }
                UI.Log("2.------- Go Start Position Done --", 0);
                System.Threading.Thread.Sleep(20);

                if (!ReadOffset())
                {
                    goto ENDTXN;
                }
                UI.Log("3.------- Offset Done -----------", 0);
                System.Threading.Thread.Sleep(20);

                int je = 0;
                string reRD = "";
                while (true)
                {
                    reRD = SWControl.ReadHand();
                    if (!reRD.Equals("RD"))
                    {
                        je++;
                        if (je > 50)
                            goto ENDTXN;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!Servo_Weight_mm("CW", 40, 150))
                {
                    goto ENDTXN;
                }
                UI.Log("3.------- Pressing Done -----------", 0);
                System.Threading.Thread.Sleep(20);

                if (!Servo_Init("CCW", 40, 400))
                {
                    goto ENDTXN;
                }
                UI.Log("4.------- Back to Start Done ------", 0);
                System.Threading.Thread.Sleep(20);

            ENDTXN:

                Servo_Finish();

                //TxnEngine.StopTxn();
                UI.Log("Txn End", 0);
                UI.UpdateFormEnable(true);
                conMain = false;
                //pressThread.Abort();
            }

        }

        int WaitHandSwitchTime = Properties.Settings.Default.WaitHandSwitchTime;
        public void PressFlowDemo()
        {
            string sMessage = "";
            UI.Log("Start Process" + countTest.ToString(), 0);
            //
            int conIndex = -1;
            foreach (ConnectorInfo CONNECTOR in Board.Info.ConnectorList)
            {
                /* -------------------------------------------------------------------------
                 * ชี้ไปยัง Tool ที่ต้องการจะใช้กด 
                 * วาดรูป และ วาดแกนของกราฟ
                 * conIndex - ใช้เป็นตัวชี้ Connector ตัวปัจจุบัน
                 * -------------------------------------------------------------------------*/
                conIndex++; // ชี้ Connector ตัวต่อไป
                //
                Board.ConnectorEntities[conIndex].Select = true; // กำหนดว่าจะเลือก สามารถยกเลิกได้ด้วย false
                Board.DrawNow(); // วาดบอร์ด
                //
                Plotter.Clear(); // ล้างข้อมูลกราฟที่อยู่ใน RAM และกำหนดตัวชี้ไปยัง Connector แรก และล้างกราฟ
                Plotter.ConnectorIndex = conIndex; // เปลี่ยนตัวชี้ไปยังตัวล่าสุด
                Plotter.DrawNow(); // วาดกราฟ - ยังไม่มีข้อมูลกราฟ มีแต่แกนและเส้นขอบเขต
                //
                UI.UpdateConnectorInfo(conIndex + 1, Board.Info.ConnectorList.Count, CONNECTOR);// แสดงข้อมูล CONNECTOR บนจอภาพหลัก
                //
                //
                /* -------------------------------------------------------------------------
                 * ขึ้น ไปที่ตำแหน่ง HOME ความสูง  = 80.0 mm    (ยังไม่ได้ตรวจสอบ ว่า ใช่ 80.0 mm หรือไม่)
                 * -------------------------------------------------------------------------*/
                sMessage = "Go to HOME position." + Environment.NewLine +
                    (CONNECTOR.ZeroHeight + CONNECTOR.ZeroClearance).ToString("0.000") + "mm , " +
                    CONNECTOR.GotoZeroSpeed.ToString("0.00") + " mm/s";
                UI.Log(sMessage, 0);
                UI.ShowMessage(sMessage);
                //if (!Servo_Init_mm("CCW", CONNECTOR.ZeroHeight + CONNECTOR.ZeroClearance, CONNECTOR.GotoZeroSpeed)) // ปิดคำสั่งไว้ เพื่อให้ Demo ได้, เปิดเมื่อต่อเครื่องจริง
                //{
                //    sMessage = "Go to home failed!";
                //    UI.Log(sMessage, 71);
                //    UI.ShowMessage(sMessage);
                //    System.Threading.Thread.Sleep(2000);
                //    UI.ShowMessage("");
                //    break;
                //}
                System.Threading.Thread.Sleep(4000); // เปิดไว้สำหรับ Demo, ปิดเมื่อต่อเครื่องจริง
                sMessage = "Done homing.";
                UI.Log(sMessage, 0);
                UI.ShowMessage(sMessage);
                System.Threading.Thread.Sleep(2000); // รอให้อ่านสักครู่
                //   
                //
                /* -------------------------------------------------------------------------
                 * ขณะที่แทนกดอยู่ที่ Home ก็ให้ผู้ใช้ใส่บอร์ดและติดตั้ง Tool และรอการกด
                 * ส่งข้อความแจ้งผู้ใช้ ให้ ผู้ใช้ดำเนินการ เมื่อเสร็จสิ้น ให้กด Hand switch
                 * -------------------------------------------------------------------------*/
                UI.UpdateFormEnable(true);
                sMessage = "Please insert connector [" + CONNECTOR.ConnectorType + "] " + Environment.NewLine +
                           "and tool [" + CONNECTOR.ToolType + "]." + Environment.NewLine + Environment.NewLine +
                           "Then, press hand-switches." + Environment.NewLine +
                           "Time : " + WaitHandSwitchTime;
                UI.Log(sMessage.Replace(Environment.NewLine, " "), 0);
                UI.ShowMessage(sMessage);
                //
                string reRD = "";
                bool handSwitchPressed = false;
                Stopwatch sw = new Stopwatch();
                sw.Reset();
                sw.Start();
                while (sw.ElapsedMilliseconds < WaitHandSwitchTime)
                {
                    sMessage = "Please insert connector [" + CONNECTOR.ConnectorType + "] " + Environment.NewLine +
                               "and tool [" + CONNECTOR.ToolType + "]." + Environment.NewLine + Environment.NewLine +
                               "Then, press hand-switches." + Environment.NewLine +
                               "Time : " + ((WaitHandSwitchTime - sw.ElapsedMilliseconds) / 1000).ToString("#0");
                    UI.ShowMessage(sMessage);
                    //
                    //reRD = SWControl.ReadHand(); // ปิดคำสั่งไว้สำหรับ Demo
                    if (reRD.Equals("RD")) { handSwitchPressed = true; break; }
                    if (sw.ElapsedMilliseconds > 3000) { handSwitchPressed = true; break; } // เปิดคำสั่งไว้สำหรับ Pressing demo
                }
                sw.Stop();
                if (!handSwitchPressed)
                {
                    sMessage = "Hand switch timed out!";
                    UI.Log(sMessage, 72);
                    UI.ShowMessage(sMessage);
                    System.Threading.Thread.Sleep(2000); // รอให้อ่านสักครู่
                    UI.ShowMessage("");
                    break;
                }
                UI.ShowMessage("");
                Plotter.DrawNow();
                UI.UpdateFormEnable(false);
                //
                /* -------------------------------------------------------------------------
                 * Profile : 0
                 * เลื่อนลง ไปที่ตำแหน่ง Unseated tool top
                 *    เป็นตำแหน่งที่อยู่เหนือ อุปกรณ์ และอาจมีการกดอยู่บ้างแล้ว
                 *    ข้อมูลยังไม่ถูก TARE
                 * -------------------------------------------------------------------------*/
                sMessage = "Go to unseated tool top." + Environment.NewLine +
                    CONNECTOR.PF_Row0_Distance.ToString("0.000") + "mm , " + Environment.NewLine +
                    CONNECTOR.SP1.ToString("0.00") + " mm/s";
                UI.Log(sMessage.Replace(Environment.NewLine, " "), 0);
                UI.ShowMessage(sMessage);
                //if (!Servo_Init_mm("CW", CONNECTOR.PF_Row0_Distance, CONNECTOR.SP1)) // ปิดคำสั่งไว้ เพื่อให้ Demo ได้, เปิดเมื่อต่อเครื่องจริง
                //{
                //    sMessage = "Go to unseated tool top failed!";
                //    UI.Log(sMessage, 73);
                //    UI.ShowMessage(sMessage);
                //    System.Threading.Thread.Sleep(2000);
                //    UI.ShowMessage("");
                //    break;
                //}
                System.Threading.Thread.Sleep(4000); // เปิดไว้สำหรับ Demo, ปิดเมื่อต่อเครื่องจริง
                UI.Log("Done go to unseated tool top.", 0);
                UI.ShowMessage("");
                //
                //if (!ReadOffset()) // Update ค่าเริ่มต้น (TARE)
                //{
                //    sMessage = "Go to unseated tool top failed!";
                //    UI.Log(sMessage, 73);
                //    UI.ShowMessage(sMessage);
                //    System.Threading.Thread.Sleep(2000);
                //    UI.ShowMessage("");
                //    break;
                //}
                UI.Log("3.------- Offset Done -----------", 0);
                System.Threading.Thread.Sleep(20);
                //







                /* -------------------------------------------------------------------------
                 * 3. อ่านข้อมูล เพื่อให้เป็นตำแหน่งที่จะดำเนินการ TARE ข้อมูล
                 * -------------------------------------------------------------------------*/
                offsetHeight = 0;
                offsetWeight = 0.0;
                UI.Log("3.------- Offset Done -----------", 0);
                System.Threading.Thread.Sleep(200);

                /* -------------------------------------------------------------------------
                 * 5. กดและบันทึกข้อมูลใส่ RAM
                 * -------------------------------------------------------------------------*/
                UI.Log("3.------- Pressing Done -----------", 0);
                double hlim = 488;
                for (int ii = 0; ii < hlim; ii++)
                {

                    /* --------------------------------------------------------
                     * Linear model Poly6:
                       f(x) = p1*x^6 + p2*x^5 + p3*x^4 + p4*x^3 + p5*x^2 + 
                                    p6*x + p7
                        Coefficients (with 95% confidence bounds):
                               p1 =  1.596e-012  (1.528e-012, 1.664e-012)
                               p2 = -2.033e-009  (-2.137e-009, -1.929e-009)
                               p3 =   9.04e-007  (8.421e-007, 9.659e-007)
                               p4 =  -0.0001675  (-0.0001855, -0.0001495)
                               p5 =     0.01416  (0.01153, 0.01678)
                               p6 =     -0.5012  (-0.6777, -0.3247)
                               p7 =       6.613  (2.44, 10.79)
                     * 
                     * --------------------------------------------------------*/

                    double p1 = 1.596e-012;
                    double p2 = -2.033e-009;
                    double p3 = 9.04e-007;
                    double p4 = -0.0001675;
                    double p5 = 0.01416;
                    double p6 = -0.5012;
                    double p7 = 6.613;

                    double x = ii;
                    double h = (hlim - x) / 100;
                    weight = p1 * x * x * x * x * x * x +
                             p2 * x * x * x * x * x +
                             p3 * x * x * x * x +
                             p4 * x * x * x +
                             p5 * x * x +
                             p6 * x +
                             p7;
                    Plotter.AddData(h, weight);
                    Plotter.Update();
                    //UI.displayMessage(posHeight.ToString() + "," + weight.ToString("#0.0"), 0);
                    System.Threading.Thread.Sleep(2);
                }

                /* -------------------------------------------------------------------------
                 * 6. ขึ้นไปยังตำแหน่งเหนืออุปกรณ์ หลังกดแล้ว
                 * -------------------------------------------------------------------------*/
                UI.Log("4.------- Back to Start Done ------", 0);
                System.Threading.Thread.Sleep(20);
                //
                UI.Log("Txn End", 0);
                UI.ShowMessage("End press fitting.");
                System.Threading.Thread.Sleep(2000);
                //
                Board.ConnectorEntities[conIndex].Select = false;
                Plotter.DrawNow();
                //
                MessageBox.Show("Hey!");
                //
            }

            UI.ShowMessage("");
            UI.UpdateFormEnable(true);

        }

        public static bool Servo_Finish()
        {
            string Code = "";
            string string_Data = "";
            string result_Data;
            int tdelay = 20;

            bool _continun = true;
            string alramRead = "12";
            while (_continun)
            {
                Code = alramRead;
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                string alramData = readDataCon();

                if (alramData.Length >= 8)
                    if (alramData.Substring(6, 2) == "DF")
                    {
                        _continun = false;
                        break;
                    }
                System.Threading.Thread.Sleep(200);
            }

            curServoStage = SERVOSTAGE._00_SERVO_OFF;

            resetAlarm();

            return true;

        }

        public static void Profile_Servo_Weight_mm(string direction,
            double distance_mm, double force, float velocity_mmps,
            out string resCode, out string resDesc)
        {
            try
            {
                string Code = "";
                string string_Data = "";
                string result_Data;
                int tdelay = 20;

                string cmdDir = "";

                switch (direction)
                {
                    case "CCW": cmdDir = "A60204";
                        break;
                    case "CW": cmdDir = "A60205";
                        break;
                    default: UI.Log("E201:Wrong Direction", 0);
                        goto EXIT;       // Wrong Command
                }

                int cmdVelo = 0;
                if (velocity_mmps <= 50 || velocity_mmps > 500)
                {
                    UI.Log("E201:Wrong Velocity", 0);
                    goto EXIT;       // Wrong Command
                }
                else
                {
                    cmdVelo = (int)(velocity_mmps * GearRatio / 60); // RPM
                }

                long cmdPos = 0;
                if (distance_mm <= 0 || distance_mm > 160)
                {
                    UI.Log("E201:Wrong Position", 0);
                    goto EXIT;       // Wrong Command
                }
                else
                {
                    //cmdPos = position * 131072;
                    cmdPos = (long)(distance_mm * (double)Denominator) / Nominator; // mm to Pulses
                }

                if (curServoStage == SERVOSTAGE._00_SERVO_OFF)
                {
                    checkAlarm();

                    string[] cmdSetInitial = {"80FF8206010100"
                                        ,"01"
                                        ,"A60201"               //Start 
                                        ,"A60202"               //Servo Off
                                        ,"A60203"               //Servo On
                                          };
                    for (int i = 0; i < cmdSetInitial.Length; i++)
                    {
                        Code = cmdSetInitial[i];
                        string_Data = Axis + Ctrl + Code;
                        send_Data(string_Data);
                        result_Data = readDataCon();

                        if (result_Data.Length >= 12)
                            if (Code == "A60202" && result_Data.Substring(8, 3) == "018")
                            {
                                curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                goto ALARM;
                            }
                            else if (Code == "A60202" && result_Data.Substring(8, 3) == "010")
                            {
                                curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                                goto ALARM;
                            }


                        //Delay(tdelay);
                        System.Threading.Thread.Sleep(tdelay);
                    }
                    curServoStage = SERVOSTAGE._10_SERVO_ON;
                }

                string[] cmdSetPosition = { "80FF821A0201" + cmdVelo.ToString("X4") // Velocity command [min-1]
                                        ,"80FF821C02010FA0"     // Acc/Dec Time constant [ms]
                                        ,"80FF821E020104B0"     // Torque (1200 = 120.0%)
                                        //,"80FF8208040100280000" // 2 cm Position command [pulse]
                                        //,"80FF8208040100500000" // 4 cm Position command [pulse]
                                        ,"80FF82080401" + cmdPos.ToString("X8") // ?? cm Position command [pulse]
                                        ,"81FF821A0201"
                                        ,"81FF821C0201"
                                        ,"81FF821E0201"
                                        ,"81FF82080401"
                                        ,"A60203"               //Servo ON
                                        ,"A60203"
                                        ,"81FF528C0201" //
                                        ,"81FF52880201" // 
                                        ,"81FF4A800801" //Check Encoder
                                        ,"A60203"
                                        ,cmdDir       // CW Direction
                                      };

                for (int i = 0; i < cmdSetPosition.Length; i++)
                {
                    Code = cmdSetPosition[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    System.Threading.Thread.Sleep(tdelay);

                }
                UI.Log("Start Run", 0);

                string[] cmdRun = {"A60206" //
                               ,"81FF528C0201"
                               ,"81FF52880201" // 
                               ,"81FF4A800801" //Check Encoder
                               };

                string[] resRun = new string[cmdRun.Length];

                bool _continue = true;
                while (_continue)
                {

                    for (int i = 0; i < cmdRun.Length; i++)
                    {
                        Code = cmdRun[i];
                        string_Data = Axis + Ctrl + Code;
                        send_Data(string_Data);
                        resRun[i] = readDataCon();
                        //System.Threading.Thread.Sleep(tdelay);
                    }

                    // Position-Weight -----------------------------------------------------------
                    try
                    {
                        posHeight = (new ElectronicsHeightStructure(resRun[3].Substring(6, 16), MechanicsRatio)).Position_mm - offsetHeight;
                        weight = Indicator.ReadDouble() - offsetWeight;
                        Plotter.AddData(posHeight, weight);
                        Plotter.Update();
                    }
                    catch { }
                    // ---------------------------------------------------------------------------

                    if (resRun[0].Length >= 12)
                        switch (resRun[0].Substring(8, 3))
                        {
                            case "0C0": curServoStage = SERVOSTAGE._30_SERVO_READY;
                                UI.Log("Finish Run", 0);
                                _continue = false;
                                break;
                            case "090": curServoStage = SERVOSTAGE._30_SERVO_READY;
                                _continue = false;
                                break;
                            case "018": curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                _continue = false;
                                break;
                            case "010": curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                                _continue = false;
                                break;
                            case "000": curServoStage = SERVOSTAGE._20_SERVO_RUN;
                                break;
                        }
                }

                if (curServoStage == SERVOSTAGE._30_SERVO_READY)
                {

                    Code = "A60207";
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();
                    System.Threading.Thread.Sleep(tdelay);

                }
                else if (curServoStage == SERVOSTAGE._40_SERVO_ALARM)
                {
                    goto ALARM;
                }
                else if (curServoStage == SERVOSTAGE._50_SERVO_EMERGENCY)
                {
                    goto EXIT;
                }

                int _count = 0;
                bool _continue2 = true;
                while (_continue2)
                {
                    Code = "A60203";
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    if (result_Data.Length >= 12)
                        switch (result_Data.Substring(8, 3))
                        {
                            case "000": curServoStage = SERVOSTAGE._10_SERVO_ON;
                                _continue2 = false;
                                break;
                            default: _count++;
                                if (_count >= 10)
                                {
                                    _continue2 = false;
                                    curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                    goto ALARM;
                                }
                                break;
                        }
                    System.Threading.Thread.Sleep(tdelay);
                }

                resCode = "00";
                resDesc = "";
                return;

            ALARM:
                string stgAlarm = readAlarm();
                UI.Log("Alarm:" + stgAlarm, 1);
                resetAlarm();
                resCode = "AL";
                resDesc = stgAlarm;
                return;

            EXIT:
                resCode = "FA";
                resDesc = "EXIT";
                return;

            }
            catch (Exception ex) { resCode = "EX"; resDesc = ex.Message; }
        }


        public static bool Servo_Init_mm(string direction, double position, float velocity_mmps)
        {
            try
            {
                string Code = "";
                string string_Data = "";
                string result_Data;
                int tdelay = 20;

                string cmdDir = "";

                switch (direction)
                {
                    case "CCW": cmdDir = "A60204";
                        break;
                    case "CW": cmdDir = "A60205";
                        break;
                    default: UI.Log("E201:Wrong Direction", 0);
                        goto EXIT;       // Wrong Command
                }

                int cmdVelo = 0;
                if (velocity_mmps <= 50 || velocity_mmps > 500)
                {
                    UI.Log("E201:Wrong Velocity", 0);
                    goto EXIT;       // Wrong Command
                }
                else
                {
                    cmdVelo = (int)(velocity_mmps * GearRatio / 60);// RPM
                }

                long cmdPos = 0;
                if (position <= 0 || position > 160)
                {
                    UI.Log("E201:Wrong Position", 0);
                    goto EXIT;       // Wrong Command
                }
                else
                {
                    //cmdPos = position * 131072;
                    cmdPos = (long)(position * (double)Denominator) / Nominator;
                }

                if (curServoStage == SERVOSTAGE._00_SERVO_OFF)
                {
                    checkAlarm();

                    string[] cmdSetInitial = {"80FF8206010100"
                                        ,"01"
                                        ,"A60201"               //Start 
                                        ,"A60202"               //Servo Off
                                        ,"A60203"               //Servo On
                                          };
                    for (int i = 0; i < cmdSetInitial.Length; i++)
                    {
                        Code = cmdSetInitial[i];
                        string_Data = Axis + Ctrl + Code;
                        send_Data(string_Data);
                        result_Data = readDataCon();

                        if (result_Data.Length >= 12)
                            if (Code == "A60202" && result_Data.Substring(8, 3) == "018")
                            {
                                curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                goto ALARM;
                            }
                            else if (Code == "A60202" && result_Data.Substring(8, 3) == "010")
                            {
                                curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                                goto ALARM;
                            }


                        //Delay(tdelay);
                        System.Threading.Thread.Sleep(tdelay);
                    }
                    curServoStage = SERVOSTAGE._10_SERVO_ON;
                }

                string[] cmdSetPosition = { "80FF821A0201" + cmdVelo.ToString("X4") // Velocity command [min-1]
                                        ,"80FF821C02010FA0"     // Acc/Dec Time constant [ms]
                                        ,"80FF821E020104B0"     // Torque (1200 = 120.0%)
                                        //,"80FF8208040100280000" // 2 cm Position command [pulse]
                                        //,"80FF8208040100500000" // 4 cm Position command [pulse]
                                        ,"80FF82080401" + cmdPos.ToString("X8") // ?? cm Position command [pulse]
                                        ,"81FF821A0201"
                                        ,"81FF821C0201"
                                        ,"81FF821E0201"
                                        ,"81FF82080401"
                                        ,"A60203"               //Servo ON
                                        ,"A60203"
                                        ,"81FF528C0201" //
                                        ,"81FF52880201" // 
                                        ,"81FF4A800801" //Check Encoder
                                        ,"A60203"
                                        ,cmdDir       // CW Direction
                                      };

                for (int i = 0; i < cmdSetPosition.Length; i++)
                {
                    Code = cmdSetPosition[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    System.Threading.Thread.Sleep(tdelay);

                }
                UI.Log("Start Run", 0);

                string[] cmdRun = {"A60206" //
                               ,"81FF528C0201"
                               ,"81FF52880201" // 
                               ,"81FF4A800801" //Check Encoder
                               };

                string[] resRun = new string[cmdRun.Length];

                bool _continue = true;
                while (_continue)
                {

                    for (int i = 0; i < cmdRun.Length; i++)
                    {
                        Code = cmdRun[i];
                        string_Data = Axis + Ctrl + Code;
                        send_Data(string_Data);
                        resRun[i] = readDataCon();
                        System.Threading.Thread.Sleep(tdelay);
                    }
                    if (resRun[0].Length >= 12)
                        switch (resRun[0].Substring(8, 3))
                        {
                            case "0C0": curServoStage = SERVOSTAGE._30_SERVO_READY;
                                UI.Log("Finish Run", 0);
                                _continue = false;
                                break;
                            case "090": curServoStage = SERVOSTAGE._30_SERVO_READY;
                                _continue = false;
                                break;
                            case "018": curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                _continue = false;
                                break;
                            case "010": curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                                _continue = false;
                                break;
                            case "000": curServoStage = SERVOSTAGE._20_SERVO_RUN;
                                break;
                        }
                }

                if (curServoStage == SERVOSTAGE._30_SERVO_READY)
                {

                    Code = "A60207";
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();
                    System.Threading.Thread.Sleep(tdelay);

                }
                else if (curServoStage == SERVOSTAGE._40_SERVO_ALARM)
                {
                    goto ALARM;
                }
                else if (curServoStage == SERVOSTAGE._50_SERVO_EMERGENCY)
                {
                    goto EXIT;
                }

                int _count = 0;
                bool _continue2 = true;
                while (_continue2)
                {
                    Code = "A60203";
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    if (result_Data.Length >= 12)
                        switch (result_Data.Substring(8, 3))
                        {
                            case "000": curServoStage = SERVOSTAGE._10_SERVO_ON;
                                _continue2 = false;
                                break;
                            default: _count++;
                                if (_count >= 10)
                                {
                                    _continue2 = false;
                                    curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                    goto ALARM;
                                }
                                break;
                        }
                    System.Threading.Thread.Sleep(tdelay);
                }

                return true;

            ALARM:
                string stgAlarm = readAlarm();
                UI.Log("Alarm:" + stgAlarm, 1);
                resetAlarm();
                return false;
            EXIT:
                return false;

            }
            catch { return false; }
        }

        public static bool Servo_Init(string direction, double position_mm, int velocity_rpm)
        {
            string Code = "";
            string string_Data = "";
            string result_Data;
            int tdelay = 20;

            string cmdDir = "";

            switch (direction)
            {
                case "CCW": cmdDir = "A60204";
                    break;
                case "CW": cmdDir = "A60205";
                    break;
                default: UI.Log("E201:Wrong Direction", 0);
                    goto EXIT;       // Wrong Command
            }

            int cmdVelo = 0;
            if (velocity_rpm <= 50 || velocity_rpm > 500)
            {
                UI.Log("E201:Wrong Velocity", 0);
                goto EXIT;       // Wrong Command
            }
            else
            {
                cmdVelo = velocity_rpm;
            }

            long cmdPos = 0;
            if (position_mm <= 0 || position_mm > 160)
            {
                UI.Log("E201:Wrong Position", 0);
                goto EXIT;       // Wrong Command
            }
            else
            {
                //cmdPos = position * 131072;
                cmdPos = (long)(position_mm * (double)Denominator) / Nominator; // mm to pulses
            }

            if (curServoStage == SERVOSTAGE._00_SERVO_OFF)
            {
                checkAlarm();

                string[] cmdSetInitial = {"80FF8206010100"
                                        ,"01"
                                        ,"A60201"               //Start 
                                        ,"A60202"               //Servo Off
                                        ,"A60203"               //Servo On
                                          };
                for (int i = 0; i < cmdSetInitial.Length; i++)
                {
                    Code = cmdSetInitial[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    if (result_Data.Length >= 12)
                        if (Code == "A60202" && result_Data.Substring(8, 3) == "018")
                        {
                            curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                            goto ALARM;
                        }
                        else if (Code == "A60202" && result_Data.Substring(8, 3) == "010")
                        {
                            curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                            goto ALARM;
                        }


                    //Delay(tdelay);
                    System.Threading.Thread.Sleep(tdelay);
                }
                curServoStage = SERVOSTAGE._10_SERVO_ON;
            }

            string[] cmdSetPosition = { "80FF821A0201" + cmdVelo.ToString("X4") // Velocity command [min-1]
                                        ,"80FF821C02010FA0"     // Acc/Dec Time constant [ms]
                                        ,"80FF821E020104B0"     // Torque (1200 = 120.0%)
                                        //,"80FF8208040100280000" // 2 cm Position command [pulse]
                                        //,"80FF8208040100500000" // 4 cm Position command [pulse]
                                        ,"80FF82080401" + cmdPos.ToString("X8") // ?? cm Position command [pulse]
                                        ,"81FF821A0201"
                                        ,"81FF821C0201"
                                        ,"81FF821E0201"
                                        ,"81FF82080401"
                                        ,"A60203"               //Servo ON
                                        ,"A60203"
                                        ,"81FF528C0201" //
                                        ,"81FF52880201" // 
                                        ,"81FF4A800801" //Check Encoder
                                        ,"A60203"
                                        ,cmdDir       // CW Direction
                                      };

            for (int i = 0; i < cmdSetPosition.Length; i++)
            {
                Code = cmdSetPosition[i];
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();

                System.Threading.Thread.Sleep(tdelay);

            }
            UI.Log("Start Run", 0);

            string[] cmdRun = {"A60206" //
                               ,"81FF528C0201"
                               ,"81FF52880201" // 
                               ,"81FF4A800801" //Check Encoder
                               };

            string[] resRun = new string[cmdRun.Length];

            bool _continue = true;
            while (_continue)
            {

                for (int i = 0; i < cmdRun.Length; i++)
                {
                    Code = cmdRun[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    resRun[i] = readDataCon();
                    System.Threading.Thread.Sleep(tdelay);
                }
                if (resRun[0].Length >= 12)
                    switch (resRun[0].Substring(8, 3))
                    {
                        case "0C0": curServoStage = SERVOSTAGE._30_SERVO_READY;
                            UI.Log("Finish Run", 0);
                            _continue = false;
                            break;
                        case "090": curServoStage = SERVOSTAGE._30_SERVO_READY;
                            _continue = false;
                            break;
                        case "018": curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                            _continue = false;
                            break;
                        case "010": curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                            _continue = false;
                            break;
                        case "000": curServoStage = SERVOSTAGE._20_SERVO_RUN;
                            break;
                    }
            }

            if (curServoStage == SERVOSTAGE._30_SERVO_READY)
            {

                Code = "A60207";
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();
                System.Threading.Thread.Sleep(tdelay);

            }
            else if (curServoStage == SERVOSTAGE._40_SERVO_ALARM)
            {
                goto ALARM;
            }
            else if (curServoStage == SERVOSTAGE._50_SERVO_EMERGENCY)
            {
                goto EXIT;
            }

            int _count = 0;
            bool _continue2 = true;
            while (_continue2)
            {
                Code = "A60203";
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();

                if (result_Data.Length >= 12)
                    switch (result_Data.Substring(8, 3))
                    {
                        case "000": curServoStage = SERVOSTAGE._10_SERVO_ON;
                            _continue2 = false;
                            break;
                        default: _count++;
                            if (_count >= 10)
                            {
                                _continue2 = false;
                                curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                goto ALARM;
                            }
                            break;
                    }
                System.Threading.Thread.Sleep(tdelay);
            }

            return true;

        ALARM:
            string stgAlarm = readAlarm();
            UI.Log("Alarm:" + stgAlarm, 1);
            resetAlarm();
            return false;
        EXIT:
            return false;

        }

        public static bool Servo_Weight_mm(string direction, double position_mm, float velocity_mmps)
        {
            string Code = "";
            string string_Data = "";
            string result_Data;
            int tdelay = 20;

            string cmdDir = "";

            switch (direction)
            {
                case "CCW": cmdDir = "A60204";
                    break;
                case "CW": cmdDir = "A60205";
                    break;
                default: UI.Log("E201:Wrong Direction", 0);
                    goto EXIT;       // Wrong Command
            }

            int cmdVelo = 0;
            if (velocity_mmps <= 50 || velocity_mmps > 500)
            {
                UI.Log("E201:Wrong Velocity", 0);
                goto EXIT;       // Wrong Command
            }
            else
            {
                cmdVelo = (int)(velocity_mmps * GearRatio / 60); // RPM
            }

            long cmdPos = 0;
            if (position_mm <= 0 || position_mm > 160)
            {
                UI.Log("E201:Wrong Position", 0);
                goto EXIT;       // Wrong Command
            }
            else
            {
                //cmdPos = position * 131072;
                cmdPos = (long)(position_mm * (double)Denominator) / Nominator; // mm to Pulses
            }

            if (curServoStage == SERVOSTAGE._00_SERVO_OFF)
            {
                checkAlarm();

                string[] cmdSetInitial = {"80FF8206010100"
                                        ,"01"
                                        ,"A60201"               //Start 
                                        ,"A60202"               //Servo Off
                                        ,"A60203"               //Servo On
                                          };
                for (int i = 0; i < cmdSetInitial.Length; i++)
                {
                    Code = cmdSetInitial[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    result_Data = readDataCon();

                    if (result_Data.Length >= 12)
                        if (Code == "A60202" && result_Data.Substring(8, 3) == "018")
                        {
                            curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                            goto ALARM;
                        }
                        else if (Code == "A60202" && result_Data.Substring(8, 3) == "010")
                        {
                            curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                            goto ALARM;
                        }


                    //Delay(tdelay);
                    System.Threading.Thread.Sleep(tdelay);
                }
                curServoStage = SERVOSTAGE._10_SERVO_ON;
            }

            string[] cmdSetPosition = { "80FF821A0201" + cmdVelo.ToString("X4") // Velocity command [min-1]
                                        ,"80FF821C02010FA0"     // Acc/Dec Time constant [ms]
                                        ,"80FF821E020104B0"     // Torque (1200 = 120.0%)
                                        //,"80FF8208040100280000" // 2 cm Position command [pulse]
                                        //,"80FF8208040100500000" // 4 cm Position command [pulse]
                                        ,"80FF82080401" + cmdPos.ToString("X8") // ?? cm Position command [pulse]
                                        ,"81FF821A0201"
                                        ,"81FF821C0201"
                                        ,"81FF821E0201"
                                        ,"81FF82080401"
                                        ,"A60203"               //Servo ON
                                        ,"A60203"
                                        ,"81FF528C0201" //
                                        ,"81FF52880201" // 
                                        ,"81FF4A800801" //Check Encoder
                                        ,"A60203"
                                        ,cmdDir       // CW Direction
                                      };

            for (int i = 0; i < cmdSetPosition.Length; i++)
            {
                Code = cmdSetPosition[i];
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();

                System.Threading.Thread.Sleep(tdelay);

            }
            UI.Log("Start Run", 0);

            string[] cmdRun = {"A60206" //
                               ,"81FF528C0201"
                               ,"81FF52880201" // 
                               ,"81FF4A800801" //Check Encoder
                               };

            string[] resRun = new string[cmdRun.Length];

            bool _continue = true;
            while (_continue)
            {

                for (int i = 0; i < cmdRun.Length; i++)
                {
                    Code = cmdRun[i];
                    string_Data = Axis + Ctrl + Code;
                    send_Data(string_Data);
                    resRun[i] = readDataCon();
                    //System.Threading.Thread.Sleep(tdelay);
                }

                // Position-Weight -----------------------------------------------------------
                try
                {
                    posHeight = (new ElectronicsHeightStructure(resRun[3].Substring(6, 16), MechanicsRatio)).Position_mm - offsetHeight;
                    weight = Indicator.ReadDouble() - offsetWeight;
                    Plotter.AddData(posHeight, weight);
                    Plotter.Update();
                }
                catch { }
                // ---------------------------------------------------------------------------

                if (resRun[0].Length >= 12)
                    switch (resRun[0].Substring(8, 3))
                    {
                        case "0C0": curServoStage = SERVOSTAGE._30_SERVO_READY;
                            UI.Log("Finish Run", 0);
                            _continue = false;
                            break;
                        case "090": curServoStage = SERVOSTAGE._30_SERVO_READY;
                            _continue = false;
                            break;
                        case "018": curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                            _continue = false;
                            break;
                        case "010": curServoStage = SERVOSTAGE._50_SERVO_EMERGENCY;
                            _continue = false;
                            break;
                        case "000": curServoStage = SERVOSTAGE._20_SERVO_RUN;
                            break;
                    }
            }

            if (curServoStage == SERVOSTAGE._30_SERVO_READY)
            {

                Code = "A60207";
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();
                System.Threading.Thread.Sleep(tdelay);

            }
            else if (curServoStage == SERVOSTAGE._40_SERVO_ALARM)
            {
                goto ALARM;
            }
            else if (curServoStage == SERVOSTAGE._50_SERVO_EMERGENCY)
            {
                goto EXIT;
            }

            int _count = 0;
            bool _continue2 = true;
            while (_continue2)
            {
                Code = "A60203";
                string_Data = Axis + Ctrl + Code;
                send_Data(string_Data);
                result_Data = readDataCon();

                if (result_Data.Length >= 12)
                    switch (result_Data.Substring(8, 3))
                    {
                        case "000": curServoStage = SERVOSTAGE._10_SERVO_ON;
                            _continue2 = false;
                            break;
                        default: _count++;
                            if (_count >= 10)
                            {
                                _continue2 = false;
                                curServoStage = SERVOSTAGE._40_SERVO_ALARM;
                                goto ALARM;
                            }
                            break;
                    }
                System.Threading.Thread.Sleep(tdelay);
            }

            return true;

        ALARM:
            string stgAlarm = readAlarm();
            UI.Log("Alarm:" + stgAlarm, 1);
            resetAlarm();
            return false;
        EXIT:
            return false;

        }

        public static bool ReadOffset()
        {
            try
            {
                string Code = "";
                string string_Data = "";
                int tdelay = 20;

                string[] cmdRun = {"81FF528C0201"
                               ,"81FF52880201" // 
                               ,"81FF4A800801" //Check Encoder
                               };

                string[] resRun = new string[cmdRun.Length];

                bool _continue = true;
                int iloop = 0;
                while (_continue)
                {

                    for (int i = 0; i < cmdRun.Length; i++)
                    {
                        Code = cmdRun[i];
                        string_Data = Axis + Ctrl + Code;
                        send_Data(string_Data);
                        resRun[i] = readDataCon();
                        System.Threading.Thread.Sleep(tdelay);
                    }

                    // Position-Weight -----------------------------------------------------------
                    try
                    {
                        offsetHeight = (new ElectronicsHeightStructure(resRun[2].Substring(6, 16), MechanicsRatio)).Position_mm;
                        offsetWeight = Indicator.ReadDouble();
                        _continue = false;
                    }
                    catch
                    {
                        iloop++;
                        if (iloop > 3)
                            return false;
                    }
                    // ---------------------------------------------------------------------------                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool checkAlarm()
        {
            char Axis = '1';
            string Ctrl = "00";
            string Code = "12";
            string String_Data = Axis + Ctrl + Code;
            send_Data(String_Data);
            string result = readDataCon();

            if (result.Length >= 4)
                if (result.Substring(2, 2) != "00")
                    resetAlarm();

            return true;
        }

        private static bool resetAlarm()
        {
            string Code = "21";
            string Data = "01";
            string String_Data = Axis + Ctrl + Code + Data;
            send_Data(String_Data);
            //readData();

            //Delay(1000);
            System.Threading.Thread.Sleep(1000);

            return true;
        }

        private static string readAlarm()
        {
            char Axis = '1';
            string Ctrl = "00";
            string Code = "12";
            string String_Data = Axis + Ctrl + Code;
            send_Data(String_Data);
            return readDataCon();
        }

        private static bool send_Data(string data)
        {
            bool result = true;
            try
            {
                string String_Data = STX.ToString() + data + ETX.ToString();

                char[] Data = new char[String_Data.Length];
                Data = String_Data.ToCharArray();

                char Bcc = (char)0x00;
                for (int i = 1; i < String_Data.Length; i++)
                {
                    Bcc = (char)(Bcc ^ Data[i]);
                }

                String_Data += Bcc;
                serialPort1.Write(String_Data);

                UI.Log(DateTime.Now.ToString("HH:mm:ss.fff") + " > " + String_Data, 0);

                Servo_Responding = false;
                result = true;
            }
            catch (Exception ex)
            {
                UI.Log("E201:" + ex.ToString(), 0);
                result = false;
            }
            return result;
        }

        private static string readDataCon()
        {
            bool _continue = true;
            string stgData;
            string masData = "";

            bool flgStart = false;
            bool flgEnd = false;
            char intData = (char)0x00;
            char intChek = (char)0x00;

            while (_continue)
            {
                try
                {
                    char dataRead = (char)serialPort1.ReadByte();
                    stgData = dataRead.ToString();//("X2")
                    if (stgData == STX.ToString()) { flgStart = true; }

                    if (flgStart)
                    {
                        masData += stgData;
                        intData = (char)(intData ^ dataRead);
                        //rtbShow.Invoke(this.myDelegate, new Object[] { stgData });

                        if (stgData == ETX.ToString())
                        {
                            intChek = (char)(intData ^ STX);
                            flgEnd = true;
                        }
                        else if (flgEnd)
                        {
                            if (intChek == dataRead)
                            {
                                _continue = false;
                                Servo_Responding = true;
                                //rtbShow.Invoke(this.myDelegate, new Object[] { Environment.NewLine });
                            }
                            else //if bit check not equal datareceive;
                            {
                                _continue = false;
                                //UI.displayMessage("W101:DataCheck>" + intChek.ToString() + ",DataRead>" + dataRead.ToString(), 0);
                            }
                        }
                    }
                }

                catch (TimeoutException e)
                {
                    UI.Log("E101:" + e.ToString(), 0);
                    _continue = false;
                }
                catch (Exception e)
                {
                    UI.Log("E100:" + e.ToString(), 0);
                    _continue = false;
                }
            }
            UI.Log(DateTime.Now.ToString("HH:mm:ss.fff") + " < " + masData, 0);

            return masData;
        }

        #endregion

        #region Save data to file

        //public static string Path = @"\My Documents\Presss Fit Pro\Data";

        //public static string FullFileName()
        //{
        //    return Path + @"\Log " + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //}

        //private void CheckPath()
        //{
        //    try
        //    {
        //        if (!Directory.Exists(Path))
        //        {
        //            Directory.CreateDirectory(Path);
        //        }
        //        if (!File.Exists(FullFileName()))
        //        {
        //            File.Create(FullFileName()).Close();
        //            int loop = 0;
        //            while (!File.Exists(FullFileName()) & loop < 30) { loop++; }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private void AppendText(string text)
        //{
        //    try
        //    {
        //        CheckPath();
        //        using (StreamWriter w = new StreamWriter(FullFileName(), true))
        //        {
        //            string str;
        //            str = DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + " : " + text;
        //            w.WriteLine(str);
        //            w.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        #endregion
    }

    #region Height structure

    public struct ElectronicsHeightStructure
    {
        public long ElectronicsPosition;
        public double Position_mm;
        public double mmRatio;

        public ElectronicsHeightStructure(string hexString, double mm_per_pulse)
        {
            ElectronicsPosition = Convert.ToInt64(hexString, 16);
            Position_mm = ElectronicsPosition * mm_per_pulse;
            mmRatio = mm_per_pulse;
        }

        public ElectronicsHeightStructure(long pulse, double mm_per_pulse)
        {
            ElectronicsPosition = pulse;
            Position_mm = ElectronicsPosition * mm_per_pulse;
            mmRatio = mm_per_pulse;
        }

        public override string ToString()
        {
            return "<" + ElectronicsPosition.ToString() + ":" + Position_mm.ToString() + ">";
        }

        public static ElectronicsHeightStructure operator -(ElectronicsHeightStructure p1, ElectronicsHeightStructure p2)
        {
            return new ElectronicsHeightStructure(p1.ElectronicsPosition - p2.ElectronicsPosition, p1.mmRatio);
        }
    }

    #endregion

    #region UI declaration

    public static class UI
    {
        public delegate void DisplayMessageCallback(string msg, int err);
        public delegate void UpdateFormEnableCallback(bool e);
        public delegate void ShowMessageCallback(string text);
        public delegate void UpdateConnectorInfoCallback(int index, int count, ConnectorInfo connector);
        //
        public static DisplayMessageCallback Log;
        public static UpdateFormEnableCallback UpdateFormEnable;
        public static ShowMessageCallback ShowMessage;
        public static UpdateConnectorInfoCallback UpdateConnectorInfo;
        //
        public static void InitUI(frmMain f)
        {
            Log = new DisplayMessageCallback(f.PostLog);
            UpdateFormEnable = new UpdateFormEnableCallback(f.PostEnable);
            ShowMessage = new ShowMessageCallback(f.PostMessage);
            UpdateConnectorInfo = new UpdateConnectorInfoCallback(f.PostConnectorInfo);
        }
    }

    #endregion
}
