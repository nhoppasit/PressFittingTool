using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Press_Fit_Pro
{
    public class ManageBiz
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        //#region msData

        //public DataSet DataShow()
        //{
        //    manageData = new ManageData();
        //    return manageData.dataShow();
        //}

        //public bool InsertData(string Name, string Email)
        //{
        //    manageData = new ManageData();
        //    return manageData.insertData(Name, Email);
        //}

        //public bool DeleteData(string Id)
        //{
        //    manageData = new ManageData();
        //    return manageData.deleteData(Id);
        //}

        //public bool UpdateData(string Id, string Name, string Email)
        //{
        //    manageData = new ManageData();
        //    return manageData.updateData(Id, Name, Email);
        //}
        //#endregion

        #region App config

        public DataTable GetAppConfig()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectAppConfig().Tables[0];
        }

        #endregion

        #region User

        public DataTable GetUserList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectUserList().Tables[0];
        }

        public DataTable GetUserBy(string user)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectUserBy(user).Tables[0];
        }

        public void AddNewUser(string userName, string firstName, string lastName, string accountType, string cript_password)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.AddNewUser(userName, firstName, lastName, accountType, cript_password);
            }
            catch { throw; }
        }

        public void DeleteUser(string userName)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.DeleteUser(userName);
            }
            catch { throw; }
        }

        #endregion

        #region Tool

        public DataTable GetToolList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectToolList().Tables[0];
        }

        public DataTable GetToolBy(string toolType)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectToolBy(toolType).Tables[0];
        }

        public void AddNewTool(string toolType, string Barcode, float clearance, float height, float width, float length, string comments)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.AddNewTool(toolType, Barcode, clearance, height, width, length, comments);
            }
            catch { throw; }
        }

        public void UpdateToolData(string toolType, string Barcode, float clearance, float height, float width, float length, string comments)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.UpdateToolData(toolType, Barcode, clearance, height, width, length, comments);
            }
            catch { throw; }
        }

        public void DeleteTool(string toolType)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.DeleteTool(toolType);
            }
            catch { throw; }
        }

        #endregion

        #region Profile

        public DataTable GetProfileList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectProfileList().Tables[0];
        }

        public DataTable GetProfileBy(string profileName)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectProfileBy(profileName).Tables[0];
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
                ManageData manageData = new ManageData();
                manageData.AddNewProfile(profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7);
            }
            catch { throw; }
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
                ManageData manageData = new ManageData();
                manageData.UpdateProfileData(profileName, sampleStart, sampleDistance,
                        Error1, Error2, Error3, Error4, Error5,
                        H1Par, H2Par, H3Par, H4Par, H5Par, H6Par, H7Par,
                        HAC1, HAC2, HAC3, HAC4, HAC5, HAC6, HAC7,
                        F1Par, F2Par, F3Par, F4Par, F5Par, F6Par, F7Par,
                        FAC1, FAC2, FAC3, FAC4, FAC5, FAC6, FAC7,
                        SP1, SP2, SP3, SP4, SP5, SP6, SP7);
            }
            catch { throw; }
        }

        public void DeleteProfile(string profileName)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.DeleteProfile(profileName);
            }
            catch { throw; }
        }

        #endregion

        #region Connector

        public DataTable GetConnectorList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectConnectorList().Tables[0];
        }

        public DataTable GetConnectorBy(string connectorType)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectConnectorBy(connectorType).Tables[0];
        }

        public void AddNewConnectorSpec(string connectorType, string toolType, string profileName,
            int pins,
            float baseThickness, float unseatedTop, float height, float seatedHeight,
            float graphFPerPin, float graphDistance,
            float minFPerPin, float maxFPerPin, float userFPerPin, float otherForce,
            float parsPercent, float parsStartHeight, float parsDistance,
            float gradDegrees, string comments)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.AddNewConnectorSpec(connectorType, toolType, profileName, pins,
                        baseThickness, unseatedTop, height, seatedHeight,
                        graphFPerPin, graphDistance,
                        minFPerPin, maxFPerPin, userFPerPin, otherForce,
                        parsPercent, parsStartHeight, parsDistance,
                        gradDegrees, comments);
            }
            catch { throw; }
        }

        public void UpdateConnectorSpec(string connectorType, string toolType, string profileName,
            int pins,
            float baseThickness, float unseatedTop, float height, float seatedHeight,
            float graphFPerPin, float graphDistance,
            float minFPerPin, float maxFPerPin, float userFPerPin, float otherForce,
            float parsPercent, float parsStartHeight, float parsDistance,
            float gradDegrees, string comments)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.UpdateConnectorSpec(connectorType, toolType, profileName, pins,
                        baseThickness, unseatedTop, height, seatedHeight,
                        graphFPerPin, graphDistance,
                        minFPerPin, maxFPerPin, userFPerPin, otherForce,
                        parsPercent, parsStartHeight, parsDistance,
                        gradDegrees, comments);
            }
            catch { throw; }
        }

        public void DeleteConnectorSpec(string connectorType)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.DeleteConnectorSpec(connectorType);
            }
            catch { throw; }
        }

        #endregion

        #region Board

        public DataTable GetBoardList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectBoardList().Tables[0];
        }

        public DataTable GetBoardBy(string boardName)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectBoardBy(boardName).Tables[0];
        }

        public DataTable GetBoardDetailBy(string boardName)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectBoardDetailBy(boardName).Tables[0];
        }

        public void AddNewBoardSpec(string boardName, string DESC, string imageFile, float boardWidth, float boardLength, float boardThickness, float fixtureThickness,
            List<int> rowList, List<float> xList, List<float> yList, List<float> angleList, List<string> connectorList, List<string> commentsList)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.AddNewBoardSpec(boardName, DESC, imageFile,
                    boardWidth, boardLength, boardThickness, fixtureThickness,
                    rowList, xList, yList, angleList, connectorList, commentsList);
            }
            catch { throw; }
        }

        public void UpdateBoardSpec(string boardName, string DESC, string imageFile, float boardWidth, float boardLength, float boardThickness, float fixtureThickness,
            List<int> rowList, List<float> xList, List<float> yList, List<float> angleList, List<string> connectorList, List<string> commentsList)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.UpdateBoardSpec(boardName, DESC, imageFile,
                    boardWidth, boardLength, boardThickness, fixtureThickness,
                    rowList, xList, yList, angleList, connectorList, commentsList);
            }
            catch { throw; }
        }

        public void DeleteBoardSpec(string boardName)
        {
            try
            {
                ManageData manageData = new ManageData();
                manageData.DeleteBoardSpec(boardName);
            }
            catch { throw; }
        }

        #endregion

        #region History

        public DataTable GetHistoryList()
        {
            ManageData manageData = new ManageData();
            return manageData.SelectRunHistoryList().Tables[0];
        }

        public DataTable GetRunHistoryBy(string boardName)
        {
            ManageData manageData = new ManageData();
            return manageData.SelectRunHistoryBy(boardName).Tables[0];
        }

        public int GetNextRunHistoryBy(string boardName)
        {
            ManageData manageData = new ManageData();
            DataTable dt = manageData.SelectNextRunHistoryBy(boardName).Tables[0];
            int runIndex = 0;
            if (dt.Rows.Count > 0)
            {
                try { runIndex = (int)dt.Rows[0]["RunIndex"]; }
                catch { runIndex = 1; }
            }
            else
            {
                runIndex = 1;
            }
            return runIndex;
        }

        private string RunHistoryPath = Properties.Settings.Default.RunHistoryPath;
        public string AddNewRunHistory(string boardName, string byWho)
        {
            try
            {
                int runIndex = GetNextRunHistoryBy(boardName);
                ManageData manageData = new ManageData();
                string historyFile = HistoryFile(boardName, runIndex);
                manageData.AddNewRunHistory(boardName, byWho, historyFile, runIndex);
                return historyFile;
            }
            catch { throw; }
        }

        public string HistoryFile(string boardName, int runIndex)
        {
            return RunHistoryPath + @"\" + boardName + "-" + runIndex.ToString() + ".dat";
        }

        #endregion
    }
}
