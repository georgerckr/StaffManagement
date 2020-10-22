using System;
using System.Buffers;
using System.Collections.Generic;

namespace StaffManagement
{
    class Program
    {
        public static void Main(string[] args)
        {   
            int choice =1;


            List<StaffOld> staff = new List<StaffOld>();
            do
            {
                Console.WriteLine("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n4.View All Staff");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Menu(staff, 1);
                        break;

                    case 2:
                        Menu(staff, 2);
                        break;

                    case 3:
                        Menu(staff, 3);
                        break;

                    case 4:

                        for (int i = 0; i < staff.Count; i++)
                        {
                            staff[i].ViewDetails(staff[i].staffID);
                        }
                        break;

                    default:
                        break;

                }
            } while (choice != 0);
        }

        static  void Menu(List<StaffOld> staff, int type)
        {
            int choice;

            do
            {

                Console.WriteLine("\nEnter Operation to be prformed \n1.Add Staff\n2.View Staff Details\n3.Update Staff \n4.Remove Staff\n");
                choice = Convert.ToInt32(Console.ReadLine());
                string Id;


                switch (choice)
                {
                    case 1:
                        switch (type)
                        {
                            case 1:
                                // staff.Add(new TeachingStaff());
                                break;
                            case 2:
                                AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                                administrativeStaff.AddStaff();
                                staff.Add(administrativeStaff);
                                break;
                            case 3:
                                //staff.Add(new SupportStaff());
                                break;
                        }
                        break;


                    case 2:
                        Console.WriteLine("\nEnter Staff ID:");
                        Id = Console.ReadLine();
                        int pos = staff.FindIndex(x => x.staffID == Id);
                        if (pos != -1)
                        {
                            staff[pos].ViewDetails(Id);
                        }
                        else
                        {
                            Console.WriteLine("\nEnter valid Staff ID");
                        }
                        break;


                    case 3:
                        Console.WriteLine("\nEnter Staff ID");
                        Id = Console.ReadLine();
                        pos = staff.FindIndex(x => x.staffID == Id);
                        if (pos != -1)
                        {
                            staff[pos].Update();
                            Console.WriteLine("\nUpdated!!");
                        }
                        else
                        {
                            Console.WriteLine("\nEnter valid Staff ID");
                        }
                        break;
                    case 4:
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
                        break;
                    default:
                        break;
                }

            } while (choice != 0);


        }
    }
}
