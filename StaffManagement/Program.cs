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
            int type,pos;

            

            do
            {
                Console.WriteLine("\nEnter Operation to be prformed \n1.Add Staff\n2.View Staff Details\n3.Update Staff \n4.Remove Staff \n5.View All Staff\n");
                choice = Convert.ToInt32(Console.ReadLine());
                string Id;

                
                switch (choice)
                {
                    case 1:
                        type = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        switch (type)
                        {
                            case 1:
                                TeachingStaff teachingStaff = new TeachingStaff();
                                teachingStaff = (TeachingStaff)StaffOperations.AddStaff(1);                               
                                staff.Add(teachingStaff);
                                break;

                            case 2:
                                AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                                administrativeStaff = (AdministrativeStaff)StaffOperations.AddStaff(2);
                                staff.Add(administrativeStaff);
                                break;
                            case 3:
                                SupportStaff supportStaff = new SupportStaff();
                                supportStaff = (SupportStaff)StaffOperations.AddStaff(3);
                                staff.Add(supportStaff);
                                break;
                        }
                        break;


                    case 2:
                        Id = AskDetails.Read("\nEnter Staff ID:");

                        pos = staff.FindIndex(x => x.StaffId == (Id));
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


                     case 4:
                         Console.WriteLine("\nEnter Staff ID");
                         Id = Console.ReadLine();
                         pos = staff.FindIndex(x => x.StaffId == Id);
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
                        for (int i = 0; i < staff.Count; i++)
                        {
                            StaffOperations.ViewDetails(staff[i]);
                            AskDetails.Print("*******************\n");
                        }
                        break;

                    default:
                        break;
                }
             
            } while (choice != 0);
        }

        
    }
}
