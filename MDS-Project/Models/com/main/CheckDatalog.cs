using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using MDS_Project.Models.com.database;
using MDS_Project.Models.com.main;
using MDS_Project.Models.com.main.bean;

namespace MDS_Project.Models.com.main
{
    public class CheckDatalog
    {
        FormatDate fd = new FormatDate();
        DataBean db = new DataBean();
        AnalysisDataErrorAndBackup adeab = new AnalysisDataErrorAndBackup();
        StoredProcedureDB spdb = new StoredProcedureDB();
        public void CheckData()
        {
            Debug.WriteLine("---Class CheckDataLog  Method CheckData---");
            String pathR = @"F:\InputData\ERRORLOG";
            
            List<String> lcd = new List<String>();

            if (File.Exists(pathR))
            {
                try
                {
                    String[] read = System.IO.File.ReadAllLines(pathR);
                    Debug.WriteLine("Contents of ERRORLOG.txt = ");
                    int length = 22, i = 0 ,j = 0;
                    String r2;
                    foreach (string r in read)
                    {
                        if(r.Length >= 23)
                        {
                            if (fd.validate(r.Substring(0, length)))
                            {
                                if (r.Contains("Error") || (r.IndexOf("Error") != -1))
                                {
                                    j = i;
                                    //Debug.WriteLine(read[j + 1].Count());
                                   //Debug.WriteLine(r + "\n" + read[j + 1] + " " + read[j + 1].Substring(35, read[j + 1].Count()-35 ) );
                                    spdb.InsertErrorLog(db.getServerID(), r.Substring(r.IndexOf("Error"), (r.IndexOf(",")) - r.IndexOf("Error")) , read[j + 1].Substring(35, read[j + 1].Count()-35).Replace("'", "") , read[j + 1].Substring(0,23));
                                    //Debug.WriteLine("i = "+ i+"I = "+(i)); ตรวจสอบความถูกต้อง

                                    lcd.Add(r.Substring(r.IndexOf("Error"), (r.IndexOf(",")) - r.IndexOf("Error")) );
                                }
                                else if (r.Contains("Backup"))
                                {
                                    Debug.WriteLine(r +" "+r.Substring(35, r.Count() - 35)+" "+r.Substring(0, 23));
                                    spdb.InsertBackupLog(1,r.Substring(35, r.Count()-35), r.Substring(0, 23));
                                }
                                else
                                {
                                   // Debug.WriteLine("Not found");
                                }
                            }
                        }
                        i++;
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine("Catch IOException =" + e);
                }

                
            }
            Debug.Write(lcd.Count()+"\n");
            db.setListData(lcd);
            adeab.CheckErrorInBase(lcd);
        }
        
    }
}