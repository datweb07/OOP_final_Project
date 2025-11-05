using System;
using System.IO;
using System.Reflection;

namespace OOP_finalProject
{
    public class GetPath
    {
        public static string path
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "DATA");
            }
        }

        //public static string path
        //{
        //    get
        //    {
        //        // Trỏ ra thư mục gốc project thay vì bin\Debug
        //        string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        //        return Path.Combine(projectDir, "JsonData");
        //    }
        //}
    }
}
