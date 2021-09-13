using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Models
{
    public class HeaderColumn
    {
        public HeaderColumn(string columnName, string propertyName, bool canSorting)
        {
            ColumnName = columnName;
            PropertyName = propertyName;
            SortExpression = propertyName;
            SortIcon = default;
            CanSorting = canSorting;
        }

        public string ColumnName { get; set; }
        public string PropertyName { get; }
        public string SortExpression { get; set; }
        public string SortIcon { get; set; }
        public bool CanSorting { get; set; }
    }
}
