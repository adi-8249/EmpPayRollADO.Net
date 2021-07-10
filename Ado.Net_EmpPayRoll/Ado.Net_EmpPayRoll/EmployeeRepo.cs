using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ado.Net_EmpPayRoll
{
    public class EmployeeRepo
    {
        public static string connectionstring = @"Data Source=DESKTOP-H386B8H\MSSQLSERVER01;Initial Catalog=payroll_service;Integrated Security=True";
        SqlConnection sql = new SqlConnection(connectionstring);
    }
}
