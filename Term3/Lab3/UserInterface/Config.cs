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
        private FileMode fileReadMode;
        private FileMode fileWriteMode;

        public FileMode FileReadMode { get => fileReadMode; set => fileReadMode = value; }
        public FileMode FileWriteMode { get => fileWriteMode; set => fileWriteMode = value; }

        Config()
        {
            fileReadMode = FileMode.Open;
            fileWriteMode = FileMode.Truncate;
        }
    }
}
