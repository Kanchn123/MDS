using MDS_Project.Models.com.database;
using MDS_Project.Models.com.main.bean;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MDS_Project.Models.com.main
{
    public class AnalysisDataErrorAndBackup
    {
        DataBean db = new DataBean();
        SelectMemoryError smr = new SelectMemoryError();
        StoredProcedureDB spdb = new StoredProcedureDB();
        QueueTrafficDataSolution qtds = new QueueTrafficDataSolution();
        NotificationError nce = new NotificationError();

        List<String> listData = new List<String>();
        List<Int32> listSol = new List<Int32>();
        private SqlDataReader reader;
        private int result;
        private DataSet ds = new DataSet();

        public void CheckErrorInBase(List<String> listData)
        {
            Debug.WriteLine("---Class AnalysisDataErrorAndBackup  Method CheckErrorInBase---");
            //listData = db.getListData();
            Debug.Write(listData.Count+"\n");//ตัวเช็คข้อมูลที่เข้ามา

            try
            {
                listData.Distinct().Count();
                /* ตัวเช็คข้อมูลตรวจสอบค่าซ้ำ */
                IEnumerable<String> distinctListData = listData.Distinct();
                /*----------------*/
                foreach (String data in distinctListData)
                {
                    Debug.Write(data + "\n");
                    result  = spdb.SeachMemoryError(data, "SQL SERVER");
                    Debug.Write(result + "\n");


                    if(result == 1) // เคยเจอ
                    {
                        ds = spdb.SeachSolutionList(data);
                        qtds.QueueData(ds);
                        
                    }
                    else if(result == 0) //ไม่เคยเจอ
                    {
                        nce.Notification();
                    }
                    else{

                    }
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Catch Exception =" + e);
            }
        }
    }
}