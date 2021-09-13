using GlobusRemote.Models;
using System;

namespace GlobusRemote.Areas.MobileBooks.Models
{
    public class FilesItemViewModel : BaseItemViewModel
    {
        public int Fid { get; set; }
        public string FtypeName { get; set; }
        public string Fname { get; set; }
        public string Fextention { get; set; }
        public int Fsize { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
    }
}