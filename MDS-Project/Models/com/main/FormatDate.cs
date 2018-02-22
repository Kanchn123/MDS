using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Query.Dynamic;

namespace MDS_Project.Models.com.main
{
    public class FormatDate
    {
        public Boolean validate(String strDate)
        {
            if (strDate.Trim().Equals(""))
            {
                return true;
            }
            else
            {
                String format = "yyyy-MM-dd HH:mm:ss.SS";
                DateTime newdate;
                try
                {
                    DateTime.TryParseExact(strDate, format, null, DateTimeStyles.None, out newdate);
                    //Debug.WriteLine(newdate);
                    return true;
                }
                catch (ParseException e)
                {
                    return false;
                }
            }
        }
    }
}