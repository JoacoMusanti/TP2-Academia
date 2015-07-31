using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
        private const string consKeyDefaultCnnString = "ConnStringExpress";
        protected SqlConnection _conn;

        protected SqlConnection SqlCon
        {
            get { return _conn; }
            set { _conn = value; }
        }

        protected void OpenConnection()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;          
            SqlCon = new SqlConnection(conString);
            SqlCon.Open();
        }

        protected void CloseConnection()
        {
            SqlCon.Close();
            SqlCon = null;
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
