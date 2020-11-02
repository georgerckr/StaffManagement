using Microsoft.VisualBasic;
using StaffManagement.Data.Interface;
using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace StaffManagement.Data
{
    [DataContract]
    [XmlRoot(ElementName = "Staff")]

    public class XMLStaffRepository : IStaffRepository
    {
        string filePath;

        XmlSerializer xmlSerializer;
        public XMLStaffRepository()
        {

            filePath = ConfigurationManager.AppSettings["xmlFilePath"];

            if (File.Exists(filePath) == false)
            {
                File.Create(filePath);


            }
            xmlSerializer = new XmlSerializer(typeof(List<Staff>),
                        new Type[] {
                            typeof(List<AdministrativeStaff>),
                            typeof(List<SupportStaff>),
                            typeof(List<TeachingStaff>)
                        });


        }



        void Serialize(List<Staff> allStaff)
        {

            try
            {
                using (TextWriter streamWriter = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(streamWriter, allStaff);
                }
            }
            catch (Exception e)
            {


                Console.WriteLine(e.Message);
            }

        }
        List<Staff> Deserialize()
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    if (fileStream.Length == 0)
                    {

                        return new List<Staff>();

                    }

                    return (List<Staff>)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch (Exception e)
            {


                Console.WriteLine(e.Message);
                return null;
            }

        }



        public void CreateStaff(Staff staff)
        {

            List<Staff> allStaff = Deserialize();
            allStaff.Add(staff);
            Serialize(allStaff);

        }

        public bool UpdateStaff(Staff newStaff)
        {
            List<Staff> allStaff = Deserialize();
            for (int i = 0; i < allStaff.Count; i++)
            {
                if (allStaff[i].StaffId == newStaff.StaffId)
                {
                    allStaff[i] = newStaff;
                    Serialize(allStaff);
                    return true;

                }

            }
            return false;
        }
        public Staff GetStaffById(int staffID)
        {
            List<Staff> allStaff = Deserialize();
            foreach (var staff in allStaff)
            {
                if (staff.StaffId == staffID)
                {
                    return staff;
                }
            }
            return null;
        }
        public bool DeleteStaff(int staffID)
        {
            List<Staff> allStaff = Deserialize();
            foreach (var staff in allStaff)
            {
                if (staff.StaffId == staffID)
                {
                    allStaff.Remove(staff);
                    Serialize(allStaff);
                    return true;
                }
            }
            return false;
        }
        public List<Staff> GetStaffByType(StaffType staffType)
        {
            List<Staff> allStaff = Deserialize();
            List<Staff> staffByType = new List<Staff>();
            foreach (var staff in allStaff)
            {
                if (staff.StaffType == staffType)
                {
                    staffByType.Add(staff);
                }
            }
            return staffByType;

        }
        public List<Staff> GetAllStaff()
        {
            List<Staff> allStaff = Deserialize();
            return allStaff;
        }

    }
}
