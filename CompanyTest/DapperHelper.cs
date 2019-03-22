using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompanyTest
{
    public  class DapperHelper
    {

        private SqlConnection conn = new SqlConnection("Data Source=47.99.244.125;Initial Catalog=LocalDB;User ID=spring;Password=Mm2717965346");

        public SqlConnection Instance()
        {
            return conn;
        } 
    }
}