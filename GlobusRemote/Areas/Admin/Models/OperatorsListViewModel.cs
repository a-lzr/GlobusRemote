using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.Admin.Models
{
    public class OperatorsListViewModel
    {
        public int Fid { get; set; }
        public string FkLanguage { get; set; }
        public string Fname { get; set; }
        public string Fpassword { get; set; }
        public bool FflagAdmin { get; set; }
        public DateTime FdateStart { get; set; }
        public DateTime? FdateFinish { get; set; }
        public bool FflagExpire { get; set; }
        public bool CanEdit { get; set; }
    }
}