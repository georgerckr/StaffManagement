using StaffManagement.Model;
using System;
using System.Buffers;
using System.Collections.Generic;
using StaffManagement.Data.Interface;
using StaffManagement.Data;
using System.Configuration;
using System.Reflection;
using System.Dynamic;

namespace StaffManagementConsole
{
    class Program
    {



        public static void Main(string[] args)
        {
            int choice;
            int staffType;

            
            Type type = Type.GetType(ConfigurationManager.AppSettings.Get("classType"));
            IStaffRepository staffRepo = (IStaffRepository)Activator.CreateInstance(type);
            


            do
            {
                choice = Convert.ToInt32(AskDetails.Read("\nEnter Operation to be prformed \n1.Add Staff\n2.View Staff Details\n3.Update Staff \n4.Remove Staff \n5.View All Staff\n6.View All Staff by Type\n7.Bulk Insert"));
                AskDetails.Print("\n*******************\n");
                string Id;


                switch (choice)
                {
                    case 1:
                        staffType = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        AskDetails.Print("\n*******************\n");
                        Staff newStaff = StaffOperations.AddStaff((StaffType)staffType);
                        staffRepo.AddStaff(newStaff);
                        break;


                    case 2:
                        Id = AskDetails.Read("\nEnter Staff ID:");
                        StaffOperations.ViewDetails(staffRepo.GetStaffById(Convert.ToInt32(Id)));
                        break;


                    case 3:
                        Id = AskDetails.Read("\nEnter Staff ID:");
                        Staff updatedStaff = staffRepo.GetStaffById(Convert.ToInt32(Id));
                        updatedStaff = StaffOperations.UpdateDetails(updatedStaff);
                        staffRepo.UpdateStaff(updatedStaff);

                        break;


                    case 4:

                        Id = AskDetails.Read("\nEnter Staff ID");
                        if (staffRepo.RemoveStaff(Convert.ToInt32(Id)))
                        {
                            AskDetails.Print("\nStaff deleted!");
                        }
                        else
                        {
                            AskDetails.Print("\nEnter valid staff ID");
                        }
                        break;
                    case 5:

                        List<Staff> staffs = staffRepo.GetAllStaff();
                        if (staffs == null)
                        {
                            AskDetails.Print("\nNo Staff details available!");
                            break;
                        }
                        foreach (var staff in staffs)
                        {
                            StaffOperations.ViewDetails(staff);
                            AskDetails.Print("\n****************");
                        }



                        break;

                    case 6:
                        staffType = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                        List<Staff> staffs1 = staffRepo.GetStaffByType((StaffType)staffType);
                        foreach (var staff in staffs1)
                        {
                            StaffOperations.ViewDetails(staff);
                            AskDetails.Print("\n****************");

                        }
                        if (staffs1 == null)
                        {
                            AskDetails.Print("\nNo Staff details available!");
                        }

                        break;
                    case 7:
                        int insertChoice = 1;
                        List<Staff> allStaff = new List<Staff>();
                        DBStaffRepository dBStaffRepository = new DBStaffRepository();
                        while (insertChoice==1)
                        {
                            staffType = Convert.ToInt32(AskDetails.Read("Enter Choice \n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n"));
                            AskDetails.Print("\n*******************\n");
                            Staff newStaff1 = StaffOperations.AddStaff((StaffType)staffType);
                            allStaff.Add(newStaff1);
                            insertChoice = Convert.ToInt32(AskDetails.Read("\nDo you want to enter another staff details?\nEnter Choice\n1.Yes\n2.No"));
                        }
                            dBStaffRepository.BulkInsert(allStaff);
                        break;
                }

            } while (choice != 0);
        }


    }
}
