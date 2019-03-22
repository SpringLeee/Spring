using Dapper;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyTest
{
    public partial class PV1 : System.Web.UI.Page
    {
        public List<PVModel> list = new List<PVModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            list = new DapperHelper().Instance().Query<PVModel>(" select * from PV order by createtime desc ").ToList();

            string action = System.Web.HttpContext.Current.Request["action"];

            if (!string.IsNullOrEmpty(action) && action == "submit")
            {
                var mobile = System.Web.HttpContext.Current.Request["mobile"];
                var starttime = System.Web.HttpContext.Current.Request["start"];
                var endtime = System.Web.HttpContext.Current.Request["end"];
                 
                var where = " where 1 = 1 ";

                if (!string.IsNullOrEmpty(mobile))
                {
                    where = where + $" and mobile like '%{mobile}%' ";
                }

                if (!string.IsNullOrEmpty(starttime))
                {
                    where = where + $" and createtime >= '{starttime.Replace("T"," ")}' ";
                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    where = where + $" and createtime >= '{endtime.Replace("T", " ")}' ";
                }   

                var items = new DapperHelper().Instance().Query<PVModel>($" select * from PV {where} order by createtime desc ").ToList();

                items.ForEach(x=> { x.ShowTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm"); }); 

                Response.Write(JsonConvert.SerializeObject(items) );
                Response.End(); 

            }

            if (!string.IsNullOrEmpty(action) && action == "import")
            {

                var mobile = System.Web.HttpContext.Current.Request["mobile"];
                var starttime = System.Web.HttpContext.Current.Request["start"];
                var endtime = System.Web.HttpContext.Current.Request["end"];

                var where = " where 1 = 1 ";

                if (!string.IsNullOrEmpty(mobile))
                {
                    where = where + $" and mobile like '%{mobile}%' ";
                }

                if (!string.IsNullOrEmpty(starttime))
                {
                    where = where + $" and createtime >= '{starttime.Replace("T", " ")}' ";
                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    where = where + $" and createtime >= '{endtime.Replace("T", " ")}' ";
                }

                var items = new DapperHelper().Instance().Query<PVModel>($" select * from PV {where} order by createtime desc ").ToList();

                items.ForEach(x => { x.ShowTime = x.CreateTime.ToString("yyyy/MM/dd HH:mm"); });


                AppLibrary.WriteExcel.XlsDocument doc = new AppLibrary.WriteExcel.XlsDocument();
                doc.FileName = "PV.xlxs";
                string SheetName = "PV";

                AppLibrary.WriteExcel.Worksheet sheet = doc.Workbook.Worksheets.Add(SheetName);
                AppLibrary.WriteExcel.Cells cells = sheet.Cells;


                //第一行表头
                cells.Add(1, 1, "手机号");
                cells.Add(1, 2, "渠道");
                cells.Add(1, 3, "时间");

                int f = 1;
                for (int m = 0; m < items.Count(); m++)
                {
                    f++;
                    cells.Add(f, 1, items[m].Mobile);
                    cells.Add(f, 2, items[m].Code);
                    cells.Add(f, 3, items[m].ShowTime);
                }


                doc.Send();  
 


            } 



        }

         


    }
}