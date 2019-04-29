﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Model
{
    public class EmployeeDataAccessLayer
    {
        readonly string connectionString = "Data Source=NIRZAF\\SQLEXPRESS01;Initial Catalog=EmployeeDB;Integrated Security=True; MultipleActiveResultSets=True;";
        //To View all employees details
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> lstemployee = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee
                        {
                            ID = Convert.ToInt32(rdr["EmployeeID"]),
                            Name = rdr["Name"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            Department = rdr["Department"].ToString(),
                            City = rdr["City"].ToString()
                        };
                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch
            {
                throw;
            }
        }
        //To Add new employee record 
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@EmpId", employee.ID);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Department", employee.Department);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the details of a particular employee
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = new Employee();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Department = rdr["Department"].ToString();
                        employee.City = rdr["City"].ToString();
                    }
                }
                return employee;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record on a particular employee
        public int DeleteEmployee(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@EmpId", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
