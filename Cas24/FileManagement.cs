using System;
using System.Collections.Generic;
using System.IO;

namespace Cas24
{
    class FileManagement
    {
        private static string FileName = @"C:\Kurs\imenik.txt";

        public static void Write(params string[] InputData)
        {
            using (StreamWriter FileHandle = new StreamWriter(FileName, true))
            {
                FileHandle.WriteLine("{0}", String.Join(";", InputData));
            }
        }

        public static List<string> Read()
        {
            List<string> ListOfNames = new List<string>();

            using (StreamReader FileHandle = new StreamReader(FileName))
            {
                string FileContents = "";
                while((FileContents = FileHandle.ReadLine()) != null)
                {
                    ListOfNames.Add(FileContents);
                }
            }

            return ListOfNames;
        }

    }
}
