using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.MobileScenarios.Models
{
    public class ScenariosActionsListViewModel
    {
        public int Fid { get; set; }
        public string FgroupName { get; set; }
        public string FtypeName { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }
        public string Fcomment { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        public bool CanEdit { get; set; }
    }
}