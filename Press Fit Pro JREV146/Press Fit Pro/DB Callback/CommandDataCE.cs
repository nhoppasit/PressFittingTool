using System;
using System.Data;
using System.Data.SqlServerCe;

namespace Press_Fit_Pro
{
    public class CommandDataCE
    {
        string ConnectionString = "Data Source =" +
            (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
             @"\PressFitProDB.sdf; Persist Security Info=False");
        //string ConnectionString = "Data Source =" +
        //    (System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) +
        //     @"\PressFitProDB.sdf; Persist Security Info=False");
        private Object _SqlCeCommand;
        private int _TIMEOUT = 14400;

        public CommandDataCE()
        {
            _SqlCeCommand = new SqlCeCommand();
        }
        public void SetCommandText(string cmdText)
        {
            ((SqlCeCommand)(this._SqlCeCommand)).Parameters.Clear();
            ((SqlCeCommand)(this._SqlCeCommand)).CommandText = cmdText;
            ((SqlCeCommand)(this._SqlCeCommand)).CommandType = CommandType.Text;
        }
        public void SetCommandStoredProcedure(string storedProcName)
        {
            // ((SqlCeCommand)(this._SqlCeCommand)).Parameters.Clear();
            ((SqlCeCommand)(this._SqlCeCommand)).CommandText = storedProcName;
            ((SqlCeCommand)(this._SqlCeCommand)).CommandType = CommandType.StoredProcedure;
        }
        public void AddInputParameter(string paramName, SqlDbType paramType, object paramValue)
        {
            SqlCeParameter param = new SqlCeParameter(paramName, paramType);
            param.Value = paramValue;
            param.Direction = ParameterDirection.Input;
            ((SqlCeCommand)(this._SqlCeCommand)).Parameters.Add(param);

        }


        public DataSet ExecuteToDataSet()
        {
            DataSet dts = new DataSet();
            using (SqlCeConnection conn = new SqlCeConnection())
            {
                conn.ConnectionString = this.ConnectionString;
                ((SqlCeCommand)(this._SqlCeCommand)).Connection = conn;
                //((SqlCeCommand)(this._SqlCeCommand)).CommandTimeout = _TIMEOUT;
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(((SqlCeCommand)(this._SqlCeCommand)));
                adapter.Fill(dts);
            }
            return dts;
        }
        public DataSet ExecuteToDataSet(DataSet typedDataSet, string tableName)
        {
            using (SqlCeConnection conn = new SqlCeConnection())
            {
                conn.ConnectionString = this.ConnectionString;
                ((SqlCeCommand)(this._SqlCeCommand)).Connection = conn;
                ((SqlCeCommand)(this._SqlCeCommand)).CommandTimeout = _TIMEOUT;
                SqlCeDataAdapter adapter = new SqlCeDataAdapter(((SqlCeCommand)(this._SqlCeCommand)));
                adapter.Fill(typedDataSet, tableName);
            }

            return typedDataSet;
        }
        public int ExecuteNonQuery()
        {
            int result = 0;

            using (SqlCeConnection conn = new SqlCeConnection())
            {
                conn.ConnectionString = this.ConnectionString;
                ((SqlCeCommand)(this._SqlCeCommand)).Connection = conn;
                //((SqlCeCommand)(this._SqlCeCommand)).CommandTimeout = _TIMEOUT;
                this.OpenConnection();
                result = ((SqlCeCommand)(this._SqlCeCommand)).ExecuteNonQuery();
                this.CloseConnection();
            }

            return result;
        }

        public void OpenConnection()
        {


            if (((SqlCeCommand)(this._SqlCeCommand)).Connection.State != ConnectionState.Open)
            {
                ((SqlCeCommand)(this._SqlCeCommand)).Connection.Open();
            }


        }
        public void CloseConnection()
        {

            if (((SqlCeCommand)(this._SqlCeCommand)).Connection.State != ConnectionState.Closed)
            {
                ((SqlCeCommand)(this._SqlCeCommand)).Connection.Close();
            }

        }
        public void ReturnConnection()
        {
            ConnectionString = null;
        }
        public void Dispose()
        {
            this.CloseConnection();
            GC.SuppressFinalize(this);
        }
    }
}
