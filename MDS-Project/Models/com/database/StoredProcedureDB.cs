using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using MDS_Project.Models.com.database.connect;
using MDS_Project.Models.com.database.bean;
using MDS_Project.Models.com.main.bean;
using System.Collections;

namespace MDS_Project.Models.com.database
{
    public class StoredProcedureDB
    {
        ConnectDB conDB = new ConnectDB();
        ConnectDBBean cdbb = new ConnectDBBean();
        DataBean db = new DataBean();
        private SqlCommand command;
        private String strSQLStored;
        private int result;
        private int resultL;
        private SqlConnection con;
        //private SqlDataReader reader;



        public int SeachMemoryError(String ErrorCode, String databaseType)
        {
            Debug.WriteLine("---Class StoredProcedureDB  Method SeachMemoryError---");
            Debug.WriteLine("---" + ErrorCode + databaseType + "--- \n");
            //conDB.OpenConnect(); //ระบบ ไม่รอรับ
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_searchmemoryerror", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Error_Code", SqlDbType.NVarChar).Value = ErrorCode;
                    cmd.Parameters.Add("@Database_Type", SqlDbType.NVarChar).Value = databaseType;
                    cmd.Parameters.Add("@CountMemoryError", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                    result = int.Parse(cmd.Parameters["@CountMemoryError"].Value.ToString());
                }
                Debug.WriteLine("__________________________________________");
                return result;
            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
                return 0;
            }

        }

        public DataSet SeachSolutionList(String ErrorCode)
        {
            Debug.WriteLine("---Class StoredProcedureDB  Method SeachSolutionList---");
            SqlDataReader reader;
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT(SL.Solution_ID),SL.MemoryError_ID FROM SolutionList SL INNER JOIN MemoryError ME ON (SL.MemoryError_ID) = (ME.MemoryError_ID) INNER JOIN Solution SOL ON (SL.Solution_ID) = (SOL.Solution_ID) WHERE  ME.Error_Code = '" + ErrorCode + "'", cn);
                    cmd.CommandType = CommandType.Text;
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds);
                    dataAdapter = null;
                }
                Debug.WriteLine("__________________________________________");
                return ds;

            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
                return null;
            }
        }


        /*------------ Insert -----------*/

        public void InsertErrorLog(Int32 Server ,String ErrorCode , String Message,String Date)
        {
            Debug.WriteLine("---Class StoredProcedureDB  Method InsertErrorLog---");
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_inserterrorlog", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Server_ID", SqlDbType.Int).Value = Server;
                    cmd.Parameters.Add("@Error_Code", SqlDbType.NVarChar).Value = ErrorCode;
                    cmd.Parameters.Add("@Error_Message", SqlDbType.NVarChar).Value = Message;
                    cmd.Parameters.Add("@Original_Date", SqlDbType.NVarChar).Value = Date;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                Debug.WriteLine("__________________________________________");
            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
            }

        }


        public void InsertBackupLog(Int32 Server, String BackupStatus, String Date)
        {
            Debug.WriteLine("---Class StoredProcedureDB  Method InsertBackupLog---");
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_insertbackuplog", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Server_ID", SqlDbType.Int).Value = Server;
                    cmd.Parameters.Add("@Backup_Status", SqlDbType.NVarChar).Value = BackupStatus;
                    cmd.Parameters.Add("@Backup_OriginalDate", SqlDbType.NVarChar).Value = Date;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                Debug.WriteLine("__________________________________________");
            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
            }

        }


        public void QueueDataSolution(Int32 Solution,Int32 MemoryError,Int32 Server)
        {
            Debug.WriteLine("---Class StoredProcedureDB  Method QueueDataSolution---");
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MDS.TEST"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("sp_insertqueuesolution", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Solution_ID", SqlDbType.Int).Value = Solution;
                    cmd.Parameters.Add("@MemoryError_ID", SqlDbType.Int).Value = MemoryError;
                    cmd.Parameters.Add("@Server_ID", SqlDbType.Int).Value = Server;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                Debug.WriteLine("__________________________________________");
            }
            catch (NullReferenceException ne)
            {
                Debug.WriteLine("Catch NullReferenceException =" + ne);
            }
            
        }


    }
}