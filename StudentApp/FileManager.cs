using System.Collections.Generic;
using System.IO;
namespace StudentApp
{
    public class FileManager
    {
        string FilePath { get; set; }

        public FileManager(string filePath)
        {
            FilePath = filePath;
        }

        public void Write(string content, bool append = true)
        {
            StreamWriter streamWriter = new StreamWriter(FilePath, append);
            using (streamWriter)
            {
                streamWriter.WriteLine(content);
                streamWriter.Flush();
            }
        }
        public IEnumerable<string> Read()
        {
            StreamReader streamReader = new StreamReader(FilePath);
            using (streamReader)
            {
                while (!streamReader.EndOfStream)
                {
                    yield return streamReader.ReadLine();
                }
            }
        }

    }
}