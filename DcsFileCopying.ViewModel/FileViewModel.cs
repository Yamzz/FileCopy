using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcsFileCopying.ViewModel
{
    public class FileViewModel
    {
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DateCopied { get; set; }
        public string CurrentFileLocation { get; set; }
        public string DestinationFileLocation { get; set; }
        public string CopyTimeElapsed { get; set; }
        public string FileExtension { get; set; }

    }
}
