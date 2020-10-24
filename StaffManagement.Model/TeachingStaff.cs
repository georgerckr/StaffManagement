using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement.Model
{
    public class TeachingStaff : Staff  
    {
       public  string subject;
        
        public TeachingStaff()
        {
            StaffType = 1;
        }
    }
}
