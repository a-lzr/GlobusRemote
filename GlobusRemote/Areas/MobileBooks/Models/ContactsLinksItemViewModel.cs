using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.MobileBooks.Models
{
    public class ContactsLinksItemViewModel
    {
        public int Fid { get; set; }
        public string Fcontact { get; set; }
        public bool FflagPrimary { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
    }
}
