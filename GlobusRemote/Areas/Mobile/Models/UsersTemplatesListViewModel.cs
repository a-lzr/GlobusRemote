using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.Mobile.Models
{
    public class UsersTemplatesListViewModel
    {
        public short Fid { get; set; }
        public string Fname { get; set; }
        public string FphoneBase { get; set; }
        public int FperiodDataExchanges { get; set; }
        public int FperiodLockWithoutDataExchange { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        public bool CanEdit { get; set; }
    }
}