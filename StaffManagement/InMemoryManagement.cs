using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagementConsole
{
    class InMemoryManagement : IMemory
    {
        public static List<Staff> staff = new List<Staff>();
        public void CreateStaff(StaffType staffType)
        {
            staff.Add(StaffOperations.AddStaff(staffType));
        }

       public void DeleteStaff(string StaffID)
        {
            int pos = staff.FindIndex(x => x.StaffId == StaffID);
            if (pos != -1)
            {
                staff.RemoveAt(pos);
                AskDetails.Print("\nRemoved!!");
            }
            else
            {
                AskDetails.Print("\nEnter valid Staff ID");
            }
        }

       public void Updatestaff(string StaffID)
        {
            int pos = staff.FindIndex(x => x.StaffId == (StaffID));
            if (pos != -1)
            {

                StaffOperations.UpdateDetails(staff[pos]);
            }
            else
            {
                AskDetails.Print("\nEnter valid Staff ID");
            }
            
        }

      public  void ViewAll()
        {
            for (int i = 0; i < staff.Count; i++)
            {
                StaffOperations.ViewDetails(staff[i]);
                AskDetails.Print("\n*******************\n");
            }
        }

      public  void ViewByType(StaffType staffType)
        {
            switch (staffType)
            {
                case StaffType.TeachingStaff:
                    for (int i = 0; i < staff.Count; i++)
                    {
                        if (staff[i].StaffType == StaffType.TeachingStaff)
                        {
                            StaffOperations.ViewDetails(staff[i]);
                            AskDetails.Print("\n*******************\n");

                        }
                    }
                    break;

                case StaffType.AdministrativeStaff:
                    for (int i = 0; i < staff.Count; i++)
                    {
                        if (staff[i].StaffType == StaffType.AdministrativeStaff)
                        {
                            StaffOperations.ViewDetails(staff[i]);
                            AskDetails.Print("\n*******************\n");
                        }
                    }
                    break;
                case StaffType.SupportStaff:
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
        }

       public void ViewStaff(string StaffID)
        {
           int pos = staff.FindIndex(x => x.StaffId == (StaffID));
            if (pos != -1)
            {

                StaffOperations.ViewDetails(staff[pos]);
            }
            else
            {
                AskDetails.Print("\nEnter valid Staff ID");
            }
        }
    }
}
