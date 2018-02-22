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
    public class QueueTrafficDataSolution
    {
        StoredProcedureDB spdb = new StoredProcedureDB();
        DataBean db = new DataBean();
        DataSet ds = new DataSet();

        public void QueueData(DataSet ds)
        {
            Debug.WriteLine("---Class QueueTrafficDataSolution  Method QueueData---");
            try
            {
                foreach (DataTable myTable in ds.Tables)
                {
                    foreach (DataRow myRow in myTable.Rows)
                    {
                        Debug.WriteLine("Solution_ID" + myRow["Solution_ID"] + "\n");
                        Debug.WriteLine("MemoryError_ID" + myRow["MemoryError_ID"] + "\n");
                        spdb.QueueDataSolution(Convert.ToInt32(myRow["Solution_ID"]), Convert.ToInt32(myRow["MemoryError_ID"]), db.getServerID());
                    }
                }

            }catch(Exception e)
            {
                Debug.WriteLine("CatchException =" + e);
            }
        }
        
    }
}