using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace StaffManagement.Model
{

  
    public class Staff
    {
        public int StaffId
        {
            get;
             set;
        }
        public string FullName { get; set; }
        public DateTime DateJoined { get; set; }
        public  StaffType StaffType { get; set; }
    }

    
}
