using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.Admin.Models
{
    public class OperatorsTemplatesListViewModel
    {
        public int Fid { get; set; }
        public string Fname { get; set; }
        public bool FflagExpire { get; set; }
        public bool CanEdit { get; set; }
    }
}