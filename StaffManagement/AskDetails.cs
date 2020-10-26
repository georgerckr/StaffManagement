using StaffManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffManagementConsole
{
    class AskDetails
    {
        public static string Read(string str)
        {
            Console.WriteLine("{0}", str);
            return (Console.ReadLine());
        }

        public static void Print(string topic, string content="")
        
        {
            Console.WriteLine("{0} {1}", topic, content);
        }
    }
}
