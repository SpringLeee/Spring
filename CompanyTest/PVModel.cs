using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyTest
{
    public class PVModel
    {
        public int Id { get; set; }

        public string Mobile { get; set; }
        public string Code { get; set; }

        public DateTime CreateTime { get; set; }

        public string ShowTime{get;set;}
    }
}