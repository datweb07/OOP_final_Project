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
    }
}
