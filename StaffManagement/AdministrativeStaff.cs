using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement
{
    class AdministrativeStaff : Staff
    {
        private string department;
      
        public override void AddStaff()
        {

            staffID = Convert.ToString(seedId++);
            
            base.AddStaff();
            Console.WriteLine("\nEnter department\n");
            department = Console.ReadLine();

            Console.WriteLine("\nAdded new staff with staff id:{0}",staffID);

        }

        public override void ViewDetails(string staffID)
        {
            base.ViewDetails(staffID);

            Console.WriteLine("\nDepartment:{0}",department);
            Console.WriteLine("\nType of Staff:Administrative Staff");



        }

      

    }
}
