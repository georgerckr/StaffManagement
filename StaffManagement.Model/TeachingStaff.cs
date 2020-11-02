using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StaffManagement.Model
{
  
    public class TeachingStaff : Staff  
    {
       public  string Subject { get; set; }
        
        public TeachingStaff()
        {
            StaffType = StaffType.TeachingStaff;
        }
    }
}
