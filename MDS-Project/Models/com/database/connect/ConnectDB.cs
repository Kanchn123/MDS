using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using MDS_Project.Models.com.database.bean;

namespace MDS_Project.Models.com.database.connect
{
    public class ConnectDB
    {

        ConnectDBBean cdbb = new ConnectDBBean();

        private SqlConnection con;
        //System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("");
        //System
        public void OpenConnect()
        {
            cdbb.setSqlConnection(new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString));
            con = cdbb.getSqlConnection();
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                Debug.WriteLine("SQL Server Connected");
            }
            else
            {
                Debug.WriteLine("SQL Server Connect Failed");
            }
        }

        public void CloseConnect()
        {
            con.Close();
            if (con.State == ConnectionState.Closed)
            {
                Debug.WriteLine("SQL Server Close Connect");
            }
            else
            {
                Debug.WriteLine("SQL Server Close Connect Failed");
            }

        }

    }

    



}