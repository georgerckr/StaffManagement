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


        }
        public void AddStaff(Staff staff)
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

        public Staff GetStaffById(int staffID)
        {
            foreach (var staff in allStaff)
            {
                if (staff.StaffId == staffID)
                {
                    return staff;
                }
            }
            return null;
        }
        public bool RemoveStaff(int StaffID)
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


    }
}
