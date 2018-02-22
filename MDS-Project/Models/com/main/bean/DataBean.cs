using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MDS_Project.Models.com.main.bean
{
    public class DataBean
    {
        //***********************
        private List<String> listData;
        private String errorCode;
        private String databaseType;
        private String date;
        public SqlDataReader reader;
        public SqlDataAdapter adapter;

        private Int32 ServerID = 1;
        private Int32[] solulist = null;
        private Int32[] memorylist = null;
        //**********************

        public Int32[] getmemorylist()
        {
            return memorylist;
        }

        public void setmemorylist(Int32[] memorylist)
        {
            this.memorylist = memorylist;
        }

        public Int32[] getsolulist()
        {
            return solulist;
        }

        public void setsolulist(Int32[] solulist)
        {
            this.solulist = solulist;
        }

        public List<String> getListData()
        {
            return listData;
        }

        public void setListData(List<String> listData)
        {
            this.listData = listData;
        }

        public String getErrorCode()
        {
            return errorCode;
        }

        public void setErrorCode(String errorCode)
        {
            this.errorCode = errorCode;
        }

        public String getDatabaseType()
        {
            return databaseType;
        }

        public void setDatabaseType(String databaseType)
        {
            this.databaseType = databaseType;
        }


        public String getDate()
        {
            return date;
        }

        public void setDate(String date)
        {
            this.date = date;
        }

        public void setServerID(Int32 ServerID)
        {
            this.ServerID = ServerID;
        }

        public Int32 getServerID()
        {
            return ServerID;
        }

        public SqlDataReader getReader()
        {
            return reader;
        }

        public void setReader(SqlDataReader reader)
        {
            this.reader = reader;
        }

        public SqlDataAdapter getAdapter()
        {
            return adapter;
        }

        public void setAdapter(SqlDataAdapter adapter)
        {
            this.adapter = adapter;
        }
    }
}