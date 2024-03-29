﻿using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagementConsole
{
    class StaffOperations
    {
        
        public static Staff AddStaff(StaffType type)
        {
            switch (type)
            {
                case StaffType.TeachingStaff:

                    TeachingStaff teachingStaff = new TeachingStaff();
                    AddCommonDetails(teachingStaff);
                    teachingStaff.Subject = AskDetails.Read("Enter Subject:");                  
                    return teachingStaff;



                case StaffType.AdministrativeStaff:

                    AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                    AddCommonDetails(administrativeStaff);
                    administrativeStaff.Department = AskDetails.Read("Enter Department");
                    administrativeStaff.Role = AskDetails.Read("Enter Role:");
                    return administrativeStaff;



                case StaffType.SupportStaff:

                    SupportStaff supportStaff = new SupportStaff();
                    AddCommonDetails(supportStaff);
                    supportStaff.Category = AskDetails.Read("Enter Category:");
                    return supportStaff;



            }
           return null;
        }

        public static Staff AddCommonDetails(Staff staff)
        {
            
            string name = AskDetails.Read("Enter Name:");
            if (String.IsNullOrEmpty(name))
            {
                AskDetails.Print("\nName cannot be null!");
                AddCommonDetails(staff);
            }
            else
            {
                staff.FullName = name;
            }

            
            staff.DateJoined= AddDateJoined();
            return staff;

        }
        public static DateTime AddDateJoined()
        {
            string date = AskDetails.Read("\nEnter Date Joined:");
            if (DateTime.TryParse(date, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                AskDetails.Print("\nEnter valid Date format");
                AddDateJoined();
            }return dateTime;
        }

        public static void ViewDetails(Staff staff)
        {
            StaffType type = staff.StaffType;
            switch ((int)type)
            {
                case 1:

                    ViewCommonDetails(staff);                    
                    TeachingStaff teachingStaff = staff as TeachingStaff;
                    AskDetails.Print("Subject:", teachingStaff.Subject);
                    break;

                case 2:
                    ViewCommonDetails(staff);
                    AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                    AskDetails.Print("Department:", administrativeStaff.Department);
                    AskDetails.Print("Role:", administrativeStaff.Role);
                    break;
                case 3:
                    ViewCommonDetails(staff);
                    SupportStaff supportStaff = staff as SupportStaff;
                    AskDetails.Print("Category:", supportStaff.Category);
                    break;
                default:
                    break;
            }



        }

        public static void ViewCommonDetails(Staff staff)
        {
            AskDetails.Print("Name:", staff.FullName);
            AskDetails.Print("Staff ID:", Convert.ToString(staff.StaffId));
            string date = staff.DateJoined.ToShortDateString();
            AskDetails.Print("Date of Joining:", date);

        }


        public static Staff UpdateDetails(Staff staff)
        {

            int choice;
                
            
            switch (staff.StaffType)
            {
                case StaffType.TeachingStaff:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Subject\n"));
                    AskDetails.Print("\n*******************\n");
                    TeachingStaff teachingStaff = staff as TeachingStaff;
                    switch (choice)
                    {
                        case 1:

                            teachingStaff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            teachingStaff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:


                            teachingStaff.Subject = AskDetails.Read("\nEnter updated Subject:");
                            break;

                        default:
                            break;
                    }
                    return teachingStaff;
                case StaffType.AdministrativeStaff:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Department\n4.Role\n"));
                    AskDetails.Print("\n*******************\n");
                    AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                    switch (choice)
                    {
                        case 1:

                            administrativeStaff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            administrativeStaff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:

                            administrativeStaff.Department = AskDetails.Read("\nEnter updated Departemnt:");
                            break;
                        case 4:

                            administrativeStaff.Role = AskDetails.Read("\nEnter updated Role:");
                            break;

                        default:
                            break;
                    }
                    return administrativeStaff;
                case StaffType.SupportStaff:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Category\n"));
                    AskDetails.Print("\n*******************\n");
                    SupportStaff supportStaff = staff as SupportStaff;
                    switch (choice)
                    {
                        case 1:

                            supportStaff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            supportStaff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:

                            supportStaff.Category = AskDetails.Read("\nEnter updated Category:");

                            break;
                    }
                    return supportStaff;
                default:
                    break;
            }

            return null;


        }
    }

}
