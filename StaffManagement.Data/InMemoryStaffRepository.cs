using StaffManagement.Data.Interface;
using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Data
{
    public class InMemoryStaffRepository : IStaffRepository
    {
        public static List<Staff> staffs = new List<Staff>();
        public void CreateStaff(Staff staff)
        {
            staffs.Add(staff);
        }

        //public void UpdateStaff(Staff staff) { }
        public bool UpdateStaff(string Id, string name, DateTime date,string extra1,string extra2)
        {
            foreach (var staff in staffs)
            {
                if (staff.StaffId == Id)
                {
                    staff.FullName = name;
                    staff.DateJoined = date;
                    switch (staff.StaffType)
                    {
                        case StaffType.TeachingStaff:
                            TeachingStaff teachingStaff = staff as TeachingStaff;
                            teachingStaff.Subject = extra1;
                            break;
                        case StaffType.AdministrativeStaff:
                            AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                            administrativeStaff.Department = extra1;
                            administrativeStaff.Role = extra2;
                            break;
                        case StaffType.SupportStaff:
                            SupportStaff supportStaff = staff as SupportStaff;
                            supportStaff.Category = extra1;
                            break;
                        default:
                            break;
                    }
                    return true;
                }

            }return false;

        }
        public Staff GetStaffById(string StaffID)
        {
            foreach (var staff in staffs)
            {
                if (staff.StaffId == StaffID)
                {
                    return staff;
                }
            }
            return null;
        }
        public bool DeleteStaff(string StaffID)
        {
            foreach (var staff in staffs)
            {
                if (staff.StaffId == StaffID)
                {
                    staffs.Remove(staff);
                    return true;
                }
            }
            return false;
        }
        public List<Staff> GetStaffByType(StaffType staffType)
        {
            List<Staff> staffByType = new List<Staff>();
            foreach (var staff in staffs)
            {
                if (staff.StaffType == staffType)
                {
                    staffByType.Add(staff);
                }
            }
            return staffByType;
        }
        public List<Staff> GetAllStaff()
        {
            return staffs;
        }
        public StaffType? FindStaffType(string staffId)
        {
            foreach (var staff in staffs)
            {
                if (staff.StaffId == staffId)
                {
                    return staff.StaffType;
                }
            }
            return null;
        }

    }
}
