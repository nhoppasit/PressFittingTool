using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Press_Fit_Pro
{
    public class ManageData
    {
        //private const string _INSERTHOSPITAL = "SP_Hospital_Insert";


        //        #region "The data"

        //        public DataSet dataShow()
        //        {
        //            DataSet ds = new DataSet();
        //            try
        //            {
        //                string stm = " SELECT [id], [name], [email] FROM [mytable] ";

        //                cmdData.SetCommandText(string.Format(stm));

        //                return cmdData.ExecuteToDataSet();
        //            }
        //            catch (Exception ex)
        //            {
        //                cmdData.ReturnConnection();
        //                throw ex;
        //            }
        //        }

        //        public bool insertData(string Name, string Email)
        //        {
        //            try
        //            {
        //                stm = @"INSERT INTO [mytable] ([name], [email]) VALUES ('{0}','{1}' ) ";
        //                cmdData.SetCommandText(string.Format(stm, Name, Email));
        //                cmdData.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                cmdData.ReturnConnection();
        //                return false;
        //                throw ex;
        //            }
        //        }

        //        public bool deleteData(string Id)
        //        {
        //            try
        //            {
        //                stm = @"DELETE FROM [mytable] WHERE id = '{0}' ";
        //                cmdData.SetCommandText(string.Format(stm, Id));
        //                cmdData.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                cmdData.ReturnConnection();
        //                return false;
        //                throw ex;
        //            }
        //        }

        //        public bool updateData(string Id, string Name, string Email)
        //        {
        //            try
        //            {
        //                stm = @"UPDATE [mytable] SET [name] = '{1}' , [email] = '{2}'   
        //                        WHERE id = '{0}'";
        //                cmdData.SetCommandText(string.Format(stm, Id, Name, Email));
        //                cmdData.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                cmdData.ReturnConnection();
        //                return false;
        //                throw ex;
        //            }
        //        }

        //        #endregion

        private string _stm;
        private CommandDataCE _cmdData;

        protected string stm
        {
            get
            {
                if (this._stm == null)
                {
                    this._stm = String.Empty;
                }
                return this._stm;
            }
            set
            {
                this._stm = value;
            }
        }

        protected CommandDataCE cmdData
        {
            get
            {
                if (this._cmdData == null)
                {
                    this._cmdData = new CommandDataCE();
                }
                return this._cmdData;
            }
            set
            {
                this._cmdData = value;
            }
        }

        #region App config

        public DataSet SelectAppConfig()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = " SELECT * FROM [tbAppConfig]";

                cmdData.SetCommandText(string.Format(stm));

                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        #endregion

        #region User

        public DataSet SelectUserList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = " SELECT [UserName], [FirstName], [LastName], [AccountType] FROM [tbUser]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectUserBy(string user)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = " SELECT [UserName], [Password] FROM [tbUser] WHERE [UserName] = '" + user + "'";

                cmdData.SetCommandText(string.Format(stm));

                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewUser(string userName, string firstName, string lastName, string accountType, string cripted_password)
        {
            try
            {
                stm = @"INSERT INTO [tbUser] ([UserName], [FirstName], [LastName], [AccountType], [Password]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}' ) ";
                cmdData.SetCommandText(string.Format(stm, userName, firstName, lastName, accountType, cripted_password));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        public void DeleteUser(string userName)
        {
            try
            {
                stm = @"DELETE FROM [tbUser] WHERE UserName = '{0}' ";
                cmdData.SetCommandText(string.Format(stm, userName));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

        #region Tool

        public DataSet SelectToolList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbTool]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectToolBy(string toolType)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbTool] WHERE [ToolType] = '" + toolType + "'";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewTool(string toolType, string Barcode, float clearance, float height, float width, float length, string comments)
        {
            try
            {
                stm = @"INSERT INTO [tbTool] ([ToolType], [Barcode], [Clearance], [Height], [Width], [Length], [Comments]) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}') ";
                cmdData.SetCommandText(string.Format(stm, toolType, Barcode, clearance, height, width, length, comments));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        public void UpdateToolData(string toolType, string Barcode, float clearance, float height, float width, float length, string comments)
        {
            try
            {
                stm = @"UPDATE [tbTool] SET [Barcode] = '{1}', [Clearance] = {2}, [Height] = {3}, [Width] = {4}, [Length] = {5}, [Comments] = '{6}' WHERE ToolType = '{0}'";
                cmdData.SetCommandText(string.Format(stm, toolType, Barcode, clearance, height, width, length, comments));
                cmdData.ExecuteNonQuery();
            }
            catch
            {
                cmdData.ReturnConnection();
                throw;
            }
        }

        public void DeleteTool(string toolType)
        {
            try
            {
                stm = @"DELETE FROM [tbTool] WHERE ToolType = '{0}' ";
                cmdData.SetCommandText(string.Format(stm, toolType));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

        #region Profile

        public DataSet SelectProfileList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbProfile]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectProfileBy(string toolType)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbProfile] WHERE [ProfileName] = '" + toolType + "'";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewProfile(string profileName, float sampleStart, float sampleDistance,
            string Error1, string Error2, string Error3, string Error4, string Error5,
            float H1Par, float H2Par, float H3Par, float H4Par, float H5Par, float H6Par, float H7Par,
            string HAC1, string HAC2, string HAC3, string HAC4, string HAC5, string HAC6, string HAC7,
            float F1Par, float F2Par, float F3Par, float F4Par, float F5Par, float F6Par, float F7Par,
            string FAC1, string FAC2, string FAC3, string FAC4, string FAC5, string FAC6, string FAC7,
            float SP1, float SP2, float SP3, float SP4, float SP5, float SP6, float SP7)
        {
            try
            {
                stm = @"INSERT INTO [tbProfile]  (ProfileName, StartHeight, Distance, 
                            Error1, Error2, Error3, Error4, Error5, 
                            H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par, 
                            HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7, 
                            F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par, 
                            FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7, 
                            SP1, SP2, SP3, SP4, SP5, SP6, SP7)
                       VALUES ('{0}', {1}, {2}, 
                            '{3}', '{4}', '{5}', '{6}', '{7}', 
                            {8}, {9}, {10}, {11}, {12}, {13}, {14},
                            '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}',
                            {22}, {23}, {24}, {25}, {26}, {27}, {28},
                            '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}',
                            {36}, {37}, {38}, {39}, {40}, {41}, {42}
                          ) ";
                cmdData.SetCommandText(string.Format(stm, profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        public void UpdateProfileData(string profileName, float sampleStart, float sampleDistance,
            string Error1, string Error2, string Error3, string Error4, string Error5,
            float H1Par, float H2Par, float H3Par, float H4Par, float H5Par, float H6Par, float H7Par,
            string HAC1, string HAC2, string HAC3, string HAC4, string HAC5, string HAC6, string HAC7,
            float F1Par, float F2Par, float F3Par, float F4Par, float F5Par, float F6Par, float F7Par,
            string FAC1, string FAC2, string FAC3, string FAC4, string FAC5, string FAC6, string FAC7,
            float SP1, float SP2, float SP3, float SP4, float SP5, float SP6, float SP7)
        {
            try
            {
                stm = @"UPDATE [tbProfile] SET StartHeight = {1}, Distance = {2}, 
                         Error1 = {3}, Error2 = {4}, Error3 = {5}, Error4 = {6}, Error5 = {7}, 
                         H1Par = {8}, H2Par = {9}, H3Par = {10}, H4Par = {11}, H5Par = {12}, H6Par = {13}, H7Par = {14}, 
                         HAC1 = {15}, HAC2 = {16}, HAC3 = {17}, HAC4 = {18}, HAC5 = {19}, HAC6 = {20}, HAC7 = {21}, 
                         F1Par = {22}, F2Par = {23}, F3Par = {24}, F4Par = {25}, F5Par = {26}, F6Par = {27}, F7Par = {28}, 
                         FAC1 = {29}, FAC2 = {30}, FAC3 = {31}, FAC4 = {32}, FAC5 = {33}, FAC6 = {34}, FAC7 = {35}, 
                         SP1 = {36}, SP2 = {37}, SP3 = {38}, SP4 = {39}, SP5 = {40}, SP6 = {41}, SP7 = {42}
                         WHERE ProfileName ='{0}'";
                cmdData.SetCommandText(string.Format(stm, profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7));
                cmdData.ExecuteNonQuery();
            }
            catch
            {
                cmdData.ReturnConnection();
                throw;
            }
        }

        public void DeleteProfile(string profileName)
        {
            try
            {
                stm = @"DELETE FROM [tbProfile] WHERE ProfileName = '{0}' ";
                cmdData.SetCommandText(string.Format(stm, profileName));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

        #region Connector

        public DataSet SelectConnectorList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbConnector]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectConnectorBy(string connectorType)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = @"SELECT * FROM [tbConnector] WHERE [connectorType] = '{0}'";
                cmdData.SetCommandText(string.Format(stm, connectorType));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewConnectorSpec(string connectorType, string toolType, string profileName,
            int pins,
            float baseThickness, float unseatedTop, float height, float seatedHeight,
            float graphFPerPin, float graphDistance,
            float minFPerPin, float maxFPerPin, float userFPerPin, float otherForce,
            float parsPercent, float parsStartHeight, float parsDistance,
            float gradDegrees,
            string comments)
        {
            try
            {
                stm = @"INSERT INTO [tbConnector] (ConnectorType, ToolType, ProfileName, NumberOfPins, 
                            BaseThickness, UnseatedTop, Height, SeatedHeight, 
                            GraphFPerPin, GraphDistance, 
                            MinFPerPin, MaxFPerPin, UserFPerPin, OtherForce, 
                            PARSPercent, PARSStartHeight, PARSDistance, FGradDegrees, Comments)
                            VALUES  ('{0}','{1}','{2}',{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},'{18}') ";
                cmdData.SetCommandText(string.Format(stm, connectorType, toolType, profileName, pins,
                            baseThickness, unseatedTop, height, seatedHeight,
                            graphFPerPin, graphDistance,
                            minFPerPin, maxFPerPin, userFPerPin, otherForce,
                            parsPercent, parsStartHeight, parsDistance, gradDegrees, comments));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        public void UpdateConnectorSpec(string connectorType, string toolType, string profileName,
            int pins,
            float baseThickness, float unseatedTop, float height, float seatedHeight,
            float graphFPerPin, float graphDistance,
            float minFPerPin, float maxFPerPin, float userFPerPin, float otherForce,
            float parsPercent, float parsStartHeight, float parsDistance,
            float gradDegrees,
            string comments)
        {
            try
            {
                stm = @"UPDATE [tbConnector] SET  ToolType ='{1}', ProfileName ='{2}', NumberOfPins ={3}, 
                            BaseThickness ={4}, UnseatedTop ={5}, Height ={6}, SeatedHeight ={7}, 
                            GraphFPerPin ={8}, GraphDistance ={9}, 
                            MinFPerPin ={10}, MaxFPerPin ={11}, UserFPerPin ={12}, OtherForce ={13}, 
                            PARSPercent ={14}, PARSStartHeight ={15}, PARSDistance ={16}, 
                            FGradDegrees ={17}, 
                            Comments ='{18}' 
                            WHERE ConnectorType ='{0}'";
                cmdData.SetCommandText(string.Format(stm, connectorType, toolType, profileName, pins,
                            baseThickness, unseatedTop, height, seatedHeight,
                            graphFPerPin, graphDistance,
                            minFPerPin, maxFPerPin, userFPerPin, otherForce,
                            parsPercent, parsStartHeight, parsDistance, gradDegrees, comments));
                cmdData.ExecuteNonQuery();
            }
            catch
            {
                cmdData.ReturnConnection();
                throw;
            }
        }

        public void DeleteConnectorSpec(string connectorType)
        {
            try
            {
                stm = @"DELETE FROM [tbConnector] WHERE ConnectorType = '{0}' ";
                cmdData.SetCommandText(string.Format(stm, connectorType));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

        #region Board

        public DataSet SelectBoardList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbBoard]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectBoardBy(string boardName)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = @"SELECT * FROM [tbBoard] WHERE [BoardName] = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectBoardDetailBy(string boardName)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = @"SELECT * FROM [tbBoardDetail] WHERE [BoardName] = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewBoardSpec(string boardName, string DESC, string imageFile, float boardWidth, float boardLength, float boardThickness, float fixtureThickness,
            List<int> rowList, List<float> xList, List<float> yList, List<float> angleList, List<string> connectorList, List<string> commentsList)
        {
            try
            {
                stm = @"INSERT INTO [tbBoard]  (BoardName, [DESC], ImageFile, BoardWidth, BoardLength, BoardThickness, FixtureThickness) VALUES 
                             ('{0}','{1}','{2}',{3},{4},{5},{6})";
                cmdData.SetCommandText(string.Format(stm, boardName, DESC, imageFile, boardWidth, boardLength, boardThickness, fixtureThickness));
                cmdData.ExecuteNonQuery();

                if (rowList != null)
                {
                    if (rowList.Count > 0)
                    {
                        stm = @"INSERT INTO [tbBoardDetail] 
                                (BoardName, RowNbr, X, Y, Angle, ConnectorType, Comments) VALUES 
                                ('{0}',{1},{2},{3},{4},'{5}','{6}')";
                        for (int i = 0; i < rowList.Count; i++)
                        {
                            cmdData.SetCommandText(string.Format(stm, boardName, rowList[i], xList[i], yList[i], angleList[i], connectorList[i], commentsList[i]));
                            cmdData.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        public void UpdateBoardSpec(string boardName, string DESC, string imageFile, float boardWidth, float boardLength, float boardThickness, float fixtureThickness,
            List<int> rowList, List<float> xList, List<float> yList, List<float> angleList, List<string> connectorList, List<string> commentsList)
        {
            try
            {
                stm = @"UPDATE [tbBoard] SET 
                            [DESC] = '{1}', ImageFile = '{2}', BoardWidth = {3}, BoardLength = {4}, BoardThickness = {5}, FixtureThickness = {6} 
                            WHERE BoardName = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName, DESC, imageFile, boardWidth, boardLength, boardThickness, fixtureThickness));
                cmdData.ExecuteNonQuery();

                stm = @"DELETE FROM tbBoardDetail WHERE BoardName = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                cmdData.ExecuteNonQuery();

                if (rowList != null)
                {
                    if (rowList.Count > 0)
                    {
                        stm = @"INSERT INTO [tbBoardDetail] 
                                (BoardName, RowNbr, X, Y, Angle, ConnectorType, Comments) VALUES 
                                ('{0}',{1},{2},{3},{4},'{5}','{6}')";
                        for (int i = 0; i < rowList.Count; i++)
                        {
                            cmdData.SetCommandText(string.Format(stm, boardName, rowList[i], xList[i], yList[i], angleList[i], connectorList[i], commentsList[i]));
                            cmdData.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
                cmdData.ReturnConnection();
                throw;
            }
        }

        public void DeleteBoardSpec(string boardName)
        {
            try
            {
                stm = @"DELETE FROM [tbBoard] WHERE BoardName = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                cmdData.ExecuteNonQuery();

                stm = @"DELETE FROM [tbBoardDetail] WHERE BoardName = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                cmdData.ExecuteNonQuery();
            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

        #region History

        public DataSet SelectRunHistoryList()
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = "SELECT * FROM [tbRunHistory]";
                cmdData.SetCommandText(string.Format(stm));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectRunHistoryBy(string boardName)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = @"SELECT * FROM [tbRunHistory] WHERE [BoardName] = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public DataSet SelectNextRunHistoryBy(string boardName)
        {
            DataSet ds = new DataSet();
            try
            {
                string stm = @"SELECT MAX(RunIndex) + 1 AS RunIndex FROM [tbRunHistory] WHERE [BoardName] = '{0}'";
                cmdData.SetCommandText(string.Format(stm, boardName));
                return cmdData.ExecuteToDataSet();
            }
            catch (Exception ex)
            {
                cmdData.ReturnConnection();
                throw ex;
            }
        }

        public void AddNewRunHistory(string boardName, string byWho, string historyFile, int runIndex)
        {
            try
            {
                stm = @"INSERT INTO [tbRunHistory]  (BoardName, ByWho, RunTime, HistoryFile, RunIndex) VALUES 
                             ('{0}', '{1}', GETDATE(), '{2}', {3})";
                cmdData.SetCommandText(string.Format(stm, boardName, byWho, historyFile, runIndex));
                cmdData.ExecuteNonQuery();

            }
            catch { cmdData.ReturnConnection(); throw; }
        }

        #endregion

    }
}
