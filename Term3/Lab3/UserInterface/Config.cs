using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserInterface
{
    public class Config
    {
        private readonly string defaultPath = System.IO.Path
            .GetFullPath(System.IO.Path
            .Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

        private FileMode fileReadMode;
        private FileMode fileWriteMode;
        private string currentEntity;

        public FileMode FileReadMode { get => fileReadMode; set => fileReadMode = value; }
        public FileMode FileWriteMode { get => fileWriteMode; set => fileWriteMode = value; }
        public string DefaultPath { get => defaultPath; }
        public string CurrentEntity { get => currentEntity; set => currentEntity = value; }

        public Config(FileMode readMode = FileMode.Open, FileMode writeMode = FileMode.Truncate)
        {
            fileReadMode = readMode;
            fileWriteMode = writeMode;
        }
    }
}
