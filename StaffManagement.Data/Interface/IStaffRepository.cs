using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Data.Interface
{
    public interface IStaffRepository
    {
        void CreateStaff(Staff staff);
        
        bool UpdateStaff(Staff staff);
        Staff GetStaffById(int staffID);
        bool DeleteStaff(int staffID);
        List<Staff> GetStaffByType(StaffType staffType);
        List<Staff> GetAllStaff();
        

    }
}
