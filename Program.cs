<<<<<<< HEAD
﻿
using OOP_finalProject.EntityForm;
using System;
=======
﻿using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainInterface());
<<<<<<< HEAD
=======

            // Tạo danh sách khách hàng mẫu
            List<Customer> customers = new List<Customer>
            {
                new Customer("KH001", "Nguyễn Văn An", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
                new Customer("KH002", "Trần Thị Bình", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
                new Customer("KH003", "Phạm Văn Cường", "Nam", "0923456789", "789 Điện Biên Phủ, Q10, TP.HCM")
            };

            // Đường dẫn file .dat (bạn đổi lại theo GetPath.path nếu muốn)
            string filePath = "Customer.dat";

            // Serialize ra file .dat
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, customers);
            }

            Console.WriteLine($"Đã tạo file {filePath} với {customers.Count} khách hàng mẫu!");
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }
    }
}
