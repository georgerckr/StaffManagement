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
            //switch (type)
            {
                //case 1:
                TeachingStaff teachingStaff = new TeachingStaff();
                AddCommonDetails(teachingStaff);
                teachingStaff.subject = AskDetails.Read(" Enter Subject:");
                AskDetails.Print("Staff created with ID:", Convert.ToString(teachingStaff.StaffId));
                return teachingStaff;

                /*break;

            case 2:
                break;

            case 3:
                break;
            default:
                break;*/

            }
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
                    AskDetails.Print("Subject:", teachingStaff.subject);
                    break;
                default:
                    break;
            }



        }

        public static void ViewCommonDetails(StaffManagement.Model.Staff staff)
        {
            AskDetails.Print("Name:", staff.FullName);
            AskDetails.Print("Staff ID:", Convert.ToString(staff.StaffId));
            AskDetails.Print("Date of Joining:", Convert.ToString(staff.DateJoined));

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

                            teachingStaff.subject = AskDetails.Read("\nEnter updated Subject:");
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }




        }
    }

}
