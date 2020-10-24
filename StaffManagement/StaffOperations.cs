using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagementConsole
{
    class StaffOperations
    {
        public static int IDSeed = 10000;
        public static Staff AddStaff(int type)
        {
            if (type == 1)
            {
                TeachingStaff teachingStaff = new TeachingStaff();
                AddCommonDetails(teachingStaff);
                teachingStaff.Subject = AskDetails.Read(" Enter Subject:");
                AskDetails.Print("Staff created with ID:", teachingStaff.StaffId);
                return teachingStaff;

            }

            else if (type == 2)
            {
                AdministrativeStaff administrativeStaff = new AdministrativeStaff();
                AddCommonDetails(administrativeStaff);
                administrativeStaff.Department = AskDetails.Read("Enter Department");
                administrativeStaff.Role = AskDetails.Read("Enter Role:");
                AskDetails.Print("Staff created with ID:", administrativeStaff.StaffId);
                return administrativeStaff;
            }


            else if (type == 3)
            {
                SupportStaff supportStaff = new SupportStaff();
                AddCommonDetails(supportStaff);
                supportStaff.Category = AskDetails.Read("Enter Category:");
                AskDetails.Print("Staff created with ID:", supportStaff.StaffId);
                return supportStaff;
            }



            return null;
        }

        public static Staff AddCommonDetails(Staff staff)
        {
            staff.StaffId = Convert.ToString(IDSeed++);
            staff.FullName = AskDetails.Read("Enter Name:");
            staff.DateJoined = Convert.ToDateTime(AskDetails.Read("Enter Date Joined:"));
            return staff;

        }

        public static void ViewDetails(Staff staff)
        {
            int type = staff.StaffType;
            switch (type)
            {
                case 1:

                    ViewCommonDetails(staff);
                    //staff = (TeachingStaff)staff;
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
                    SupportStaff supportStaff = new SupportStaff();
                    AskDetails.Print("Category:", supportStaff.Category);
                    break;
                default:
                    break;
            }



        }

        public static void ViewCommonDetails(StaffManagement.Model.Staff staff)
        {
            AskDetails.Print("Name:", staff.FullName);
            AskDetails.Print("Staff ID:", Convert.ToString(staff.StaffId));
            string date = staff.DateJoined.ToShortDateString();
            AskDetails.Print("Date of Joining:", date);

        }

        public static void UpdateDetails(Staff staff)
        {

            int choice;
            int type = staff.StaffType;
            switch (type)
            {
                case 1:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Subject\n"));
                    switch (choice)
                    {
                        case 1:

                            staff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            staff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:
                            TeachingStaff teachingStaff = staff as TeachingStaff;

                            teachingStaff.Subject = AskDetails.Read("\nEnter updated Subject:");
                            break;

                        default:
                            break;
                    }
                    break;
                case 2:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Department\n4.Role\n"));
                    switch (choice)
                    {
                        case 1:

                            staff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            staff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:
                            AdministrativeStaff administrativeStaff = staff as AdministrativeStaff;
                            administrativeStaff.Department = AskDetails.Read("\nEnter updated Departemnt:");
                            break;
                        case 4:
                            AdministrativeStaff administrativeStaff1 = staff as AdministrativeStaff;
                            administrativeStaff1.Role = AskDetails.Read("\nEnter updated Role:");
                            break;

                        default:
                            break;
                    }
                    break;
                case 3:
                    choice = Convert.ToInt32(AskDetails.Read("\nEnter choice \n1.Name\n2.Date of Joining\n3.Category\n"));
                    switch (choice)
                    {
                        case 1:

                            staff.FullName = AskDetails.Read("\nEnter updated Name:");
                            break;

                        case 2:
                            staff.DateJoined = Convert.ToDateTime(AskDetails.Read("\nEnter updated Date:"));
                            break;

                        case 3:
                            SupportStaff supportStaff = staff as SupportStaff;
                           supportStaff.Category = AskDetails.Read("\nEnter updated Category:");
                           
                            break;
                    }
                    break;
                default:
                    break;
            }




        }
    }

}
