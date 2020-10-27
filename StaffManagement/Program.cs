using StaffManagement.Model;
using System;
using System.Buffers;
using System.Collections.Generic;

namespace StaffManagementConsole
{
    class Program
    {
      


        public static void Main(string[] args)
        {
            int choice = 1;
            int type;
            

            InMemoryManagement inMemory = new InMemoryManagement();

            do
            {
                choice = Convert.ToInt32(AskDetails.Read("\nEnter Operation to be prformed \n1.Add Staff\n2.View Staff Details\n3.Update Staff \n4.Remove Staff \n5.View All Staff\n6.View All Staff by Type"));
                AskDetails.Print("\n*******************\n");
                string Id;


                switch (choice)
                {
                    case 1:
                        type = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        AskDetails.Print("\n*******************\n");
                        inMemory.CreateStaff((StaffType)type);
                        break;


                    case 2:
                        Id = AskDetails.Read("\nEnter Staff ID:");
                        inMemory.ViewStaff(Id);
                        break;


                    case 3:
                        Id = AskDetails.Read("\nEnter Staff ID:");
                        inMemory.Updatestaff(Id);
                        break;


                    case 4:

                        Id = AskDetails.Read("\nEnter Staff ID");
                        inMemory.DeleteStaff(Id);
                        break;
                    case 5:
                        
                        inMemory.ViewAll();
                        break;

                    case 6:
                        type = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        inMemory.ViewByType((StaffType)type);
                        break;
                }

            } while (choice != 0);
        }


    }
}
