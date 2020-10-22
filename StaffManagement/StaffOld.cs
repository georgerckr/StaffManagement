using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagement
{
     class StaffOld
    {
        protected static int seedId = 10000;
       
        protected string staffName;
        protected string staffAddress;
        protected long staffPhone;
        protected double staffSalary;
      
        public string staffID;


        public virtual void AddStaff()
        {
            Console.WriteLine("\nEnter Name:");
            staffName = Console.ReadLine();          
            Console.WriteLine("\nEnter Address:");
            staffAddress = Console.ReadLine();
            Console.WriteLine("\nEnter Phone Number:");
            staffPhone = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("\nEnter Salary:");
            staffSalary = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void ViewDetails(string staffID)
        {
            Console.WriteLine("\nName:{0}", staffName);
            Console.WriteLine("Staff ID:{0}", staffID);
            Console.WriteLine("\nAddress:{0}", staffAddress);
            Console.WriteLine("\tPhone Number:{0}", staffPhone);
            Console.WriteLine("\nSalary : {0}", staffSalary);
        }

       

        public void Update()
        {
            Console.WriteLine("\nEnter choice \n1.Name\n2.Address\n3.Salary\n");
            int choice = Convert.ToInt32(Console.ReadLine());
             

            switch (choice)
            {
                case 1:
                     Console.WriteLine("\nEnter updated Name:");
                    staffName = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("\nEnter updated Address:");
                    staffAddress = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("\nEnter updated Salary:");
                    staffSalary = Convert.ToDouble(Console.ReadLine());
                    break;
                
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }

    }
}
