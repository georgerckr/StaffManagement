using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Data.Interface
{
    public interface IStaffRepository
    {
        void CreateStaff(Staff staff);
        //void UpdateStaff(Staff staff);
        bool UpdateStaff(Staff staff);
        Staff GetStaffById(string StaffID);
        bool DeleteStaff(string StaffID);
        List<Staff> GetStaffByType(StaffType staffType);
        List<Staff> GetAllStaff();
        StaffType? FindStaffType(string staffId);

    }
}
