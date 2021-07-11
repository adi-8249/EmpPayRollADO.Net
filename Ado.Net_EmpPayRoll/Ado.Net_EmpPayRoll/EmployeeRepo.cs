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
       

        public void GetAllEmployee()
        {
            try //When an exception occurs, the control will move to the catch block
            {
                EmpPayroll payroll = new EmpPayroll();
                using (this.sql)
                {
                    string query = @"select * from EmployeePayRoll";
                    //SqlCommand is interact with reational database or stored procedure to execute against SQL Server datdabase.
                    SqlCommand cmd = new SqlCommand(query, this.sql);
                    this.sql.Open();
                    //SqlDataReader Provides a way of reading a forward-only stream of rows from a SQL Server database.
                    SqlDataReader dr = cmd.ExecuteReader(); 
                    if (dr.HasRows)
                    {              
                        while (dr.Read())
                        {
                            payroll.EmployeeID = dr.GetInt32(0);
                            payroll.EmployeeName = dr.GetString(1);
                            payroll.Salary = dr.GetDouble(2);
                            payroll.StartDate = dr.GetDateTime(3);
                            payroll.Gender = dr.GetString(4);
                            payroll.PhoneNumber = dr.GetString(5);
                            payroll.Department = dr.GetString(6);
                            payroll.Address = dr.GetString(7);
                            payroll.BasicPay = dr.GetDouble(8);
                            payroll.Deduction = dr.GetDouble(9);
                            payroll.TaxablePay = dr.GetDouble(10);
                            payroll.IncomeTax = dr.GetDouble(11);
                            payroll.NetPay = dr.GetDouble(12);
                            Console.WriteLine(payroll.EmployeeID + " " + payroll.EmployeeName + " " + payroll.Salary + " " + payroll.StartDate + " " + payroll.Gender + " " + payroll.PhoneNumber + " " + payroll.Department + " " + payroll.Address + " " + payroll.BasicPay + " " + payroll.Deduction + " " + payroll.TaxablePay + " " + payroll.IncomeTax + " " + payroll.NetPay);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    //close data reader
                    dr.Close();
                    this.sql.Close();
                }
            }
            catch (Exception e) //Catch/Handle the exception  
            {
                Console.WriteLine(e.Message);
            }
            finally //this block of code will always get executed whether an exception occurs or not.
            {
                this.sql.Close();
            }
        }
    }
}
