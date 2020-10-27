using System;

namespace StaffManagement.Model
{
    public class Staff
    {
        public string StaffId
        {
            get;
             set;
        }
        public string FullName { get; set; }
        public DateTime DateJoined { get; set; }
        public  StaffType StaffType { get; set; }
    }

    
}
