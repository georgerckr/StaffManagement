
using StaffManagement.Data.Interface;
using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace StaffManagement.Data
{
    public class DBStaffRepository : IStaffRepository
    {
        SqlConnection sqlConnection;
        public DBStaffRepository()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["dbConnection"]);


        }

        public void AddStaff(Staff staff)
        {
            string Subject = null, Role = null, Category = null, Department = null;

            switch (staff.StaffType)
            {
                case StaffType.TeachingStaff:
                    TeachingStaff teachingStaff = staff as TeachingStaff;
                    Subject = teachingStaff.Subject;
                    break;
                case StaffType.AdministrativeStaff:
                    AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                    Department = administrativeStaff.Department;
                    Role = administrativeStaff.Role;
                    break;
                case StaffType.SupportStaff:
                    SupportStaff supportStaff = staff as SupportStaff;
                    Category = supportStaff.Category;
                    break;
                default:
                    break;
            }

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("proc_InsertStaff", sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FullName", staff.FullName);
                    sqlCommand.Parameters.AddWithValue("@DateJoined", staff.DateJoined);
                    sqlCommand.Parameters.AddWithValue("@StaffType", staff.StaffType);
                    sqlCommand.Parameters.AddWithValue("@Department", Department);
                    sqlCommand.Parameters.AddWithValue("@Role", Role);
                    sqlCommand.Parameters.AddWithValue("@Category", Category);
                    sqlCommand.Parameters.AddWithValue("@Subject", Subject);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool RemoveStaff(int staffID)
        {
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("proc_RemoveStaff", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SID", staffID);
                    sqlConnection.Open();
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                    else
                    {

                        return false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                sqlConnection.Close();

            }
        }

        public List<Staff> GetAllStaff()
        {
            try
            {
                List<Staff> allStaff = new List<Staff>();
                using (SqlCommand sqlCommand = new SqlCommand("proc_GetAllStaff", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    allStaff = ReadStaff(sqlDataReader);
                    sqlDataReader.Close();
                    return allStaff;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public Staff GetStaffById(int staffID)
        {

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("proc_GetStaffByID", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("SID", staffID);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    Staff staff = ReadStaff(sqlDataReader)[0];
                    sqlDataReader.Close();
                    return staff;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Staff> GetStaffByType(StaffType staffType)
        {

            try
            {
                List<Staff> staffByType = new List<Staff>();
                using (SqlCommand sqlCommand = new SqlCommand("proc_GetStaffByType", sqlConnection))
                {


                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@StaffType", staffType);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    staffByType = ReadStaff(sqlDataReader);
                    sqlDataReader.Close();
                    sqlCommand.Dispose();
                    return staffByType;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public bool UpdateStaff(Staff staff)
        {
            string Subject = null, Role = null, Category = null, Department = null;

            switch (staff.StaffType)
            {
                case StaffType.TeachingStaff:
                    TeachingStaff teachingStaff = staff as TeachingStaff;
                    Subject = teachingStaff.Subject;
                    break;
                case StaffType.AdministrativeStaff:
                    AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                    Department = administrativeStaff.Department;
                    Role = administrativeStaff.Role;
                    break;
                case StaffType.SupportStaff:
                    SupportStaff supportStaff = staff as SupportStaff;
                    Category = supportStaff.Category;
                    break;
                default:
                    break;
            }

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("proc_UpdateStaff", sqlConnection))
                {

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SID", staff.StaffId);
                    sqlCommand.Parameters.AddWithValue("@FullName", staff.FullName);
                    sqlCommand.Parameters.AddWithValue("@DateJoined", staff.DateJoined);
                    sqlCommand.Parameters.AddWithValue("@Department", Department);
                    sqlCommand.Parameters.AddWithValue("@Role", Role);
                    sqlCommand.Parameters.AddWithValue("@Category", Category);
                    sqlCommand.Parameters.AddWithValue("@Subject", Subject);
                    sqlConnection.Open();
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                    else
                    {

                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Staff> ReadStaff(SqlDataReader sqlDataReader)
        {
            List<Staff> staffs = new List<Staff>();
            while (sqlDataReader.Read())
            {
               
                StaffType stafftype = (StaffType)Enum.Parse(typeof(StaffType), sqlDataReader["StaffType"].ToString());
                switch (stafftype)
                {
                    case StaffType.TeachingStaff:
                        TeachingStaff staff = new TeachingStaff();

                        staff.FullName = sqlDataReader["FullName"].ToString();
                        staff.StaffId = Convert.ToInt32(sqlDataReader["SID"]);
                        staff.DateJoined = (DateTime)sqlDataReader["DateJoined"];
                        staff.StaffType = (StaffType)Enum.Parse(typeof(StaffType), sqlDataReader["StaffType"].ToString());
                        staff.Subject = sqlDataReader["Subject"].ToString();
                        staffs.Add(staff);
                        break;
                    case StaffType.AdministrativeStaff:
                        AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                        administrativeStaff.FullName = sqlDataReader["FullName"].ToString();
                        administrativeStaff.StaffId = Convert.ToInt32(sqlDataReader["SID"]);
                        administrativeStaff.DateJoined = (DateTime)sqlDataReader["DateJoined"];
                        administrativeStaff.StaffType = (StaffType)Enum.Parse(typeof(StaffType), sqlDataReader["StaffType"].ToString());
                        administrativeStaff.Department = sqlDataReader["Department"].ToString();
                        administrativeStaff.Role = sqlDataReader["Role"].ToString();
                        staffs.Add(administrativeStaff);
                        break;
                    case StaffType.SupportStaff:
                        SupportStaff supportStaff = new SupportStaff();
                        supportStaff.FullName = sqlDataReader["FullName"].ToString();
                        supportStaff.StaffId = Convert.ToInt32(sqlDataReader["SID"]);
                        supportStaff.DateJoined = (DateTime)sqlDataReader["DateJoined"];
                        supportStaff.StaffType = (StaffType)Enum.Parse(typeof(StaffType), sqlDataReader["StaffType"].ToString());
                        supportStaff.Category = sqlDataReader["Category"].ToString();
                        staffs.Add(supportStaff);
                        break;
                    default:
                        break;
                }
            }
            return staffs;
        }




    }
}
