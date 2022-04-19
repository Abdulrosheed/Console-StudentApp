using System.IO;
using System.Collections.Generic;
using System.Collections;
namespace HospitalApp
{
    public class FileManager
    {
        private string FileName { get; set; }

        public FileManager(string fileName)
        {
            FileName = fileName;
        }
        public IEnumerable<string> ReadFile()
        {
            StreamReader reader = new StreamReader(FileName);
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }

        }

        public void WriteToFile(string content)
        {
            StreamWriter writer = new StreamWriter(FileName, true);
            using (writer)
            {
                writer.WriteLine(content);
                writer.Flush();
            }
        }

        public void RefreshFile(string content)
        {
            StreamWriter writer = new StreamWriter(FileName);
            using (writer)
            {
                writer.WriteLine(content);
                writer.Flush();
            }
        }
    }


}