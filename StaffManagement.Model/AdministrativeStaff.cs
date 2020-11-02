using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StaffManagement.Model
{
   
    public class AdministrativeStaff : Staff
    {
        public string Department { get; set; }
        public string Role { get; set; }
        public AdministrativeStaff()
        {
            StaffType = StaffType.AdministrativeStaff;
        }

    }
}
