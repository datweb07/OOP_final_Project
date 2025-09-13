using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOP_finalProject
{
    public class GetPath
    {
        public static string path 
        { 
            get 
            { 
                return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "JsonData"); 
            } 
        }
    }
}
