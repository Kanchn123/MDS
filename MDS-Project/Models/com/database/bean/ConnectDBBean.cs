using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MDS_Project.Models.com.database.bean
{
    public class ConnectDBBean
    {
        private SqlConnection con;

        public void setSqlConnection(SqlConnection con)
        {
            this.con = con;
        }

        public SqlConnection getSqlConnection()
        {
            return con;
        }



    }
}