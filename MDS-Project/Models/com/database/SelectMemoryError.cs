using MDS_Project.Models.com.database.bean;
using MDS_Project.Models.com.database.connect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MDS_Project.Models.com.database
{
    public class SelectMemoryError
    {
        ConnectDB conDB = new ConnectDB();
        ConnectDBBean cdbb = new ConnectDBBean();
        private SqlCommand command;
        private SqlDataReader reader;
        private String strSQL;
        private SqlDataReader result;
        private SqlConnection con;

        public void Select()
        {
            Debug.WriteLine("---Class Select Method SeachMemoryError---");
            //conDB.OpenConnect();

            try
            {
                cdbb.setSqlConnection(new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString));
                con = cdbb.getSqlConnection();
                con.Open();
                strSQL = "SELECT * FROM MemoryError";
                SqlCommand command = new SqlCommand();

                command.Connection = cdbb.getSqlConnection();
                command.CommandText = strSQL;
                command.CommandType = CommandType.Text;

                result = command.ExecuteReader();
                while (result.Read())
                {
                    Debug.WriteLine("result = " + result[0] + "\n");
                }
                

            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
               
            }
            catch (InvalidCastException ie)
            {
                
            }
        }
    }
}