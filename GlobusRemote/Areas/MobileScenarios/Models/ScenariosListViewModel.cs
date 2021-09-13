using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.MobileScenarios.Models
{
    public class ScenariosListViewModel
    {
        public int Fid { get; set; }
        public string Fname { get; set; }
        public string FtypeName { get; set; }
        public bool FflagInputDateManual { get; set; }
        public bool FflagSendConfirm { get; set; }
        public bool FflagExpire { get; set; }
        public string Fcomment { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        public bool CanEdit { get; set; }
    }
}