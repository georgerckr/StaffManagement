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
        Staff GetStaffById(string staffID);
        bool DeleteStaff(string staffID);
        List<Staff> GetStaffByType(StaffType staffType);
        List<Staff> GetAllStaff();
        

    }
}
