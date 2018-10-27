using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataAccessLayer
{
    public class TextDataAccessor : IDataAccessor
    {
        public string BaseDirectoryPath { get; set; } =
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DataAccessLayer"));
        //  C:\Users\Bogdan\Desktop\Lab1\Lab1\DataAccessLayer\
        //  ../../../../DataAccessLayer/
        private string FilePath { get; set; }
        public TextDataAccessor(string path)
        {
            bool isFullPath = Regex.IsMatch(path, @"\w:(\\w+)+\.\w+");
            bool isShortPath = Regex.IsMatch(path, @"(?x) (?<!( \w:(\\w+)+) )\w+\.\w+");
            if (isShortPath)
                path = Path.GetFullPath(Path.Combine(BaseDirectoryPath, path));
            else if (!isFullPath)
                throw new ArgumentException("Invalid path.");

            if (!File.Exists(path))
                throw new FileNotFoundException("No such file found at " + FilePath);
            FilePath = path;
        }

        public string Read()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException("No such file found at " + FilePath);

            /* Read from file */
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
            using (TextReader reader = new StreamReader(fileStream))
                return reader.ReadToEnd();
        }

        /* TRUNCATE OR APPEND */
        public void Write(string data, FileMode fileMode)
        {
            /*
             * TODO ADD CHECKS FOR EACH POSSIBLE fileMode
             */
            if (!File.Exists(FilePath))
                throw new FileNotFoundException("No such file found at " + FilePath);

            /* Write to file */
            using (FileStream fileStream = new FileStream(FilePath, fileMode))
            using (TextWriter writer = new StreamWriter(fileStream))
                writer.Write(data);
        }

        public void Clear()
        {
            if (!File.Exists(FilePath))
                throw new FileNotFoundException("No such file found at " + FilePath);

            /* Fill file with empty string */
            using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
            using (TextWriter writer = new StreamWriter(fileStream))
                writer.Write(string.Empty);
        }
    }
}
