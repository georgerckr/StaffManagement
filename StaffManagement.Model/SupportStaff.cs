using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StaffManagement.Model
{
    public class SupportStaff : Staff
    {
        public SupportStaff()
        {
            StaffType = 3;

        }
        public string Category { get; set; }

    }
}