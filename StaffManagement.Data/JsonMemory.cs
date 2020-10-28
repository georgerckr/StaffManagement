//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using StaffManagement.Data.Interface;
//using StaffManagement.Model;
//using System.Collections.Generic;
//using System.IO;

//namespace StaffManagement.Data
//{
//    class JsonMemory : IStaffRepository
//    {
//        string filePath = @"C:\Users\user\source\repos\StaffManagement\StaffManagement\JsonData";
//        public static List<Staff> staffs = new List<Staff>();
//        JsonSerializer jsonSerializer = new JsonSerializer();
      

//        public void CreateStaff(StaffType staffType)
//        {
//            Staff staff = StaffOperations.AddStaff(staffType);
            
//             //using (StreamWriter streamWriter = new StreamWriter(filePath,true))
//             //jsonSerializer.Serialize(streamWriter, staff);
//            staffs.Add(staff);
//            string jString = JsonConvert.SerializeObject(staffs, Formatting.Indented);
//            File.WriteAllText(filePath, jString);







//        }

//        public void UpdateStaff(string StaffID)
//        {
//            //using (StreamReader streamReader = new StreamReader(filePath))
//            //{
//            //    Staff staff;
//            //    string stream;
//            //    while ((stream = streamReader.ReadLine()) != null)
//            //    {

//            //        staff = JsonSerializer.Deserialize<Staff>(stream);

//            //        if (staff.StaffId == StaffID)
//            //        {
//            //            StaffOperations.UpdateDetails(staff);

//            //        }

//            //    }
//            //}
//        }
//        public void ViewStaff(string StaffID) { }
//        public void DeleteStaff(string StaffID) { }
//        public void ViewByType(StaffType staffType) { }
//        public void ViewAll() { }



//    }
//}



