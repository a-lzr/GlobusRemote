using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GlobusRemote.Models
{
    public class BaseItemViewModel
    {
        public BaseItemViewModel()
        {
            EditInfo = new BaseEditItemViewModel();
        }

        public object this[string propertyName]
        {
            get { return GetType().GetProperty(propertyName).GetValue(this, null); }
            set { GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public BaseEditItemViewModel EditInfo { get; set; }
    }
}
