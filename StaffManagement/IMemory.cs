using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagementConsole
{
    interface IMemory
    {
        void CreateStaff(StaffType staffType);
        void Updatestaff(string StaffID);
        void ViewStaff(string StaffID);
        void DeleteStaff(string StaffID);
        void ViewByType(StaffType staffType);
        void ViewAll();

    }
}
