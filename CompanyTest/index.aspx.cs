using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CompanyTest
{
    public partial class index : System.Web.UI.Page
    {
        public string code = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            code = System.Web.HttpContext.Current.Request["code"] ?? "APK1";

            string action = System.Web.HttpContext.Current.Request["action"];

            if (!string.IsNullOrEmpty(action))
            {
                string mobile = (System.Web.HttpContext.Current.Request["mobile"] ?? string.Empty).Trim();
                string code = (System.Web.HttpContext.Current.Request["code"] ?? string.Empty).Trim();

                // 记录
                var sql = $" insert into PV values ( '{mobile}','{DateTime.Now}','{code}' ) ";
                new DapperHelper().Instance().Execute(sql);


                // 返回文件

                if (code.ToUpper() == "APK1" || code.ToUpper() == "APK2")
                {
                    Response.Clear();

                    Response.Buffer = true;

                    Response.AddHeader("Content-Disposition", "attachment;filename=" + $"{code.ToUpper()}.apk");

                    Response.ContentType = "application/unknow";

                    Response.TransmitFile(Server.MapPath($"/Files/{code.ToUpper()}.apk"));

                    Response.End();
                } 

            } 

        }
    }
}