using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace StaffManagement.Model
{
    
    public class SupportStaff : Staff
    {
        public string Category { get; set; }
        public SupportStaff()
        {
            StaffType =StaffType.SupportStaff;

        }
       

    }
}