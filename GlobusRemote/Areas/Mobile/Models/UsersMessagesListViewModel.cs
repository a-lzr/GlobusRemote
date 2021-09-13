using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.Mobile.Models
{
    public class UsersMessagesListViewModel
    {
        public int Fid { get; set; }
        public int FparentLink { get; set; }
        public int FscenarioName { get; set; }
        public byte FtypeName { get; set; }
        public string FcodeResponse { get; set; }
        public DateTime Fdate { get; set; }
        public string Ftext { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        public bool CanEdit { get; set; }
    }
}