// <copyright file=OurBook>
// Copyright (c) 2023 All Rights Reserved
// </copyright>
// <author>Joseph Thurlow</author>
// <date> 28/03/2023 8:46:58 PM</date>
// <summary>Main class for OurBook</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurBook
{
    static class OurBook
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OBLogin());
        }
    }
}



/// Code used temporarily to generate copyright for each file. 
//List<string> files = new List<string>()
//            {
//                "OBAdmin.cs",
//                "OBHome.cs",
//                "OBLogin.cs",
//                "OBRegistration.cs",
//                "OBAdminCreate.cs",
//                "User.cs",
//                "Bill.cs"
//            };

//foreach (string filename in files)
//{
//    string file = "c:\\Users\\josep\\source\\repos\\OurBook\\OurBook\\" + filename;
//    string tempFile = Path.GetFullPath(file) + ".tmp";

//    using (StreamReader reader = new StreamReader(file))
//    {
//        using (StreamWriter writer = new StreamWriter(tempFile))
//        {
//            writer.WriteLine(@"// <copyright file=" + Path.GetFileNameWithoutExtension(file) + @">
//// Copyright (c) 2023 All Rights Reserved
//// </copyright>
//// <author>Joseph Thurlow</author>
//// <date> " + DateTime.Now + @"</date>
//// <summary>Class representing a Sample entity</summary>
//");

//            string line = string.Empty;
//            while ((line = reader.ReadLine()) != null)
//            {
//                writer.WriteLine(line);
//            }
//        }
//    }
//    File.Delete(file);
//    File.Move(tempFile, file);
//}