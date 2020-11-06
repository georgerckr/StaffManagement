using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Data.Interface
{
    public interface IStaffRepository
    {
        void AddStaff(Staff staff);
        
        bool UpdateStaff(Staff staff);
        Staff GetStaffById(int staffID);
        bool RemoveStaff(int staffID);
        List<Staff> GetStaffByType(StaffType staffType);
        List<Staff> GetAllStaff();
        

    }
}
