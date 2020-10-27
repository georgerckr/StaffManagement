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
            int type, pos;
            int choiceStaff;



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
                        staff.Add(StaffOperations.AddStaff(type));
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

                        Id = AskDetails.Read("\nEnter Staff ID");
                        pos = staff.FindIndex(x => x.StaffId == Id);
                        if (pos != -1)
                        {
                            staff.RemoveAt(pos);
                            AskDetails.Print("\nRemoved!!");
                        }
                        else
                        {
                            AskDetails.Print("\nEnter valid Staff ID");
                        }
                        break;
                    case 5:
                        for (int i = 0; i < staff.Count; i++)
                        {
                            StaffOperations.ViewDetails(staff[i]);
                            AskDetails.Print("\n*******************\n");
                        }
                        break;

                    case 6:
                        choiceStaff = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        switch (choiceStaff)
                        {
                            case 1:
                                for (int i = 0; i < staff.Count; i++)
                                {
                                    if(staff[i].StaffType==StaffType.TeachingStaff)
                                   { 
                                    StaffOperations.ViewDetails(staff[i]);
                                    AskDetails.Print("\n*******************\n");                                   
                                    
                                    }
                                }
                                break;

                            case 2:
                                for (int i = 0; i < staff.Count; i++)
                                {
                                    if (staff[i].StaffType == StaffType.AdministrativeStaff)
                                    {
                                        StaffOperations.ViewDetails(staff[i]);
                                        AskDetails.Print("\n*******************\n");
                                    }
                                }
                                break;
                            case 3:
                                for (int i = 0; i < staff.Count; i++)
                                {
                                    if (staff[i].StaffType == StaffType.SupportStaff)
                                    {
                                        StaffOperations.ViewDetails(staff[i]);
                                        AskDetails.Print("\n*******************\n");
                                    }
                                }
                                break;


                            default:
                                AskDetails.Print("\nEnter valid choice");
                                break;
                        }

                        break;
                }
                
            } while (choice != 0);
        }


    }
}
