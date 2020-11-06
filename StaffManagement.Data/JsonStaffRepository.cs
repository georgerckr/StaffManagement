using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StaffManagement.Data.Interface;
using StaffManagement.Model;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace StaffManagement.Data
{
    public class JsonStaffRepository : IStaffRepository
    {
        JsonSerializerSettings settings;
        string filePath;
        public JsonStaffRepository()
        {

            filePath = ConfigurationManager.AppSettings["jsonFilePath"];
            settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto,Formatting = Formatting.Indented };
            if (File.Exists(filePath)==false)
            {
                File.Create(filePath);

            }
            
        }



        void Serialize(List<Staff> allStaff)
        {
            string jsonStream = JsonConvert.SerializeObject(allStaff, settings);
            File.WriteAllText(filePath, jsonStream);
        }
        List<Staff> Deserialize()
        {
            string jsonStream = File.ReadAllText(filePath);
            if (string.IsNullOrEmpty(jsonStream))
            {
                return new List<Staff>();
                
            }
            return JsonConvert.DeserializeObject<List<Staff>>(jsonStream, settings);
        }



        public void AddStaff(Staff staff)
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
        public bool RemoveStaff(int staffID)
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



