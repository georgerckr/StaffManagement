using StaffManagement.Data.Interface;
using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Data
{
    public class InMemoryStaffRepository : IStaffRepository
    {
        List<Staff> allStaff;
        public InMemoryStaffRepository()
        {
            allStaff = new List<Staff>();
            SupportStaff supportStaff = new SupportStaff()
            {
                Category = "cs",
                FullName = "George",
                StaffId = "20000",
                DateJoined = new DateTime(1998, 5, 5)


            };
            AdministrativeStaff administrativeStaff = new AdministrativeStaff();
            administrativeStaff.FullName = "Roy";
            administrativeStaff.Department = "cs";
            administrativeStaff.DateJoined = new DateTime(2004, 5, 5);
            administrativeStaff.StaffId = "25000";
            administrativeStaff.Role = "VC";
            allStaff.Add(administrativeStaff);
            allStaff.Add(supportStaff);


        }
        public void CreateStaff(Staff staff)
        {
            allStaff.Add(staff);
        }

        public bool UpdateStaff(Staff newStaff)
        {

            for (int i = 0; i < allStaff.Count; i++)
            {
                if (allStaff[i].StaffId == newStaff.StaffId)
                {
                    allStaff[i] = newStaff;
                    return true;

                }

            }
            return false;
        }
        //public bool UpdateStaff(string Id, string name, DateTime date,string extra1,string extra2)
        //{
        //    foreach (var staff in staffs)
        //    {
        //        if (staff.StaffId == Id)
        //        {
        //            staff.FullName = name;
        //            staff.DateJoined = date;
        //            switch (staff.StaffType)
        //            {
        //                case StaffType.TeachingStaff:
        //                    TeachingStaff teachingStaff = staff as TeachingStaff;
        //                    teachingStaff.Subject = extra1;
        //                    break;
        //                case StaffType.AdministrativeStaff:
        //                    AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
        //                    administrativeStaff.Department = extra1;
        //                    administrativeStaff.Role = extra2;
        //                    break;
        //                case StaffType.SupportStaff:
        //                    SupportStaff supportStaff = staff as SupportStaff;
        //                    supportStaff.Category = extra1;
        //                    break;
        //                default:
        //                    break;
        //            }
        //            return true;
        //        }

        //    }return false;

        //}
        public Staff GetStaffById(string StaffID)
        {
            foreach (var staff in allStaff)
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
            foreach (var staff in allStaff)
            {
                if (staff.StaffId == StaffID)
                {
                    allStaff.Remove(staff);
                    return true;
                }
            }
            return false;
        }
        public List<Staff> GetStaffByType(StaffType staffType)
        {
            List<Staff> staffByType = new List<Staff>();
            foreach (var staff in allStaff)
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
            return allStaff;
        }
        public StaffType? FindStaffType(string staffId)
        {
            foreach (var staff in allStaff)
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
