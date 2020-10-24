using StaffManagement.Model;
using System;
using System.Buffers;
using System.Collections.Generic;

namespace StaffManagementConsole
{
    class Program
    {
        public static List<Staff> staff = new List<Staff>();

        public static void Main(string[] args)
        {
            int choice = 1;

            //Staff staff = new TeachingStaff();
            // (staff1 as TeachingStaff).

            do
            {
                Console.WriteLine("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Menu(staff, 1);
                        break;

                    case 2:
                        //Menu(staff, 2);
                        break;

                    case 3:
                        //Menu(staff, 3);
                        break;



                    default:
                        break;

                }
            } while (choice != 0);
        }

        static void Menu(List<Staff> staff, int type)
        {
            int choice;
            int pos;

            do
            {

                Console.WriteLine("\nEnter Operation to be prformed \n1.Add Staff\n2.View Staff Details\n3.Update Staff \n");
                choice = Convert.ToInt32(Console.ReadLine());
                string Id;
                //StaffOperations staffOperations = new StaffOperations();

                switch (choice)
                {
                    case 1:
                        switch (type)
                        {
                            case 1:
                                TeachingStaff teachingStaff = new TeachingStaff();
                                teachingStaff = (TeachingStaff)StaffOperations.AddStaff(1);
                                staff.Add(teachingStaff);
                                break;

                            case 2:
                                break;
                            case 3:
                                //staff.Add(new SupportStaff());
                                break;
                        }
                        break;


                    case 2:
                        Id = AskDetails.Read("\nEnter Staff ID:");

                         pos = staff.FindIndex(x => x.StaffId ==(Id));
                        if (pos != -1)
                        {
                            
                            StaffOperations.ViewDetails(staff[pos]);
                        }
                        else
                        {
                            AskDetails.Print("\nEnter valid Staff ID");
                        }
                        break;


                    case 3:
                        Id = AskDetails.Read("\nEnter Staff ID:");

                        pos = staff.FindIndex(x => x.StaffId == (Id));
                        if (pos != -1)
                        {

                            StaffOperations.UpdateDetails(staff[pos]);
                        }
                        else
                        {
                            AskDetails.Print("\nEnter valid Staff ID");
                        }
                        break;

                        
                   /* case 4:
                        Console.WriteLine("\nEnter Staff ID");
                        Id = Console.ReadLine();
                        pos = staff.FindIndex(x => x.staffID == Id);
                        if (pos != -1)
                        {
                            staff.RemoveAt(pos);
                            Console.WriteLine("\nRemoved!!");
                        }
                        else
                        {
                            Console.WriteLine("\nEnter valid Staff ID");
                        }
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;*/
                    default:
                        break;
                }

            } while (choice != 0);


        }
    }
}
