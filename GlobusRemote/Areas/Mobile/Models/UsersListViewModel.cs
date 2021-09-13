using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.Mobile.Models
{
    public class UsersListViewModel
    {
        public int Fid { get; set; }
        public string Fcode { get; set; }
        public string Fphone { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        public bool CanEdit { get; set; }
    }
}