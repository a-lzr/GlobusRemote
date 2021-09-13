using GlobusRemote.Models;
using System;
using System.Collections.Generic;

namespace GlobusRemote.Areas.MobileBooks.Models
{
    public class ContactsItemViewModel : BaseItemViewModel
    {
        public ContactsItemViewModel() : base ()
        {
            ContactsLinks = new HashSet<ContactsLinksItemViewModel>();
        }

        public int Fid { get; set; }
        public string Fcode { get; set; }
        public string Fname { get; set; }
        public string Fcomment { get; set; }
        public bool FflagExpire { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
        
        public HashSet<ContactsLinksItemViewModel> ContactsLinks { get; set; }
    }
}