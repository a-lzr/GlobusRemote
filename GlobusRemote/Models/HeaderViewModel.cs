using GlobusRemote.Data.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Models
{
    public class HeaderViewModel
    {        
        private readonly string UpIcon = "SortUp";
        private readonly string DownIcon = "SortDown";

        private List<HeaderColumn> columns = new List<HeaderColumn>();

        public string SortedField { get; set; }
        public SortDirections SortedDirection { get; set; }
        public string SortedCurrent { get; set; }
        public string SortedExpression { get; set; }

        public List<HeaderColumn> Columns { get => columns; }

        public void AddColumn(string colId, string colName, bool canSorting = true, bool defaultSorting = false)
        {
            var column = Columns
                .Where(c => c.ColumnName.ToLower() == colName.ToLower()).SingleOrDefault();

            if (column == null)
            {
                Columns.Add(new HeaderColumn(colId, colName, canSorting));
            }

            if (defaultSorting)
            {
                SortedField = colName;
                SortedDirection = SortDirections.Ascending;
            }
        }

        public HeaderColumn GetColumn(string colName)
        {
            return Columns
                .Where(c => c.ColumnName.ToLower() == colName.ToLower()).SingleOrDefault();
        }

        public void ApplySort(string sort)
        {
            if (String.IsNullOrEmpty(sort))
            { 
                sort = SortedField; // default sorting
            }

            if (!String.IsNullOrEmpty(sort))
            {
                sort = sort.ToLower();
            }

            columns.ForEach(column => {
                if (sort == column.SortExpression.ToLower())
                {
                    SortedField = column.SortExpression;
                    SortedDirection = SortDirections.Ascending;
                    SortedCurrent = column.SortExpression;
                    SortedExpression = column.SortExpression + "_desc";
                    column.SortExpression = column.SortExpression + "_desc";
                    column.SortIcon = DownIcon;
                }
                else if (sort == column.SortExpression.ToLower() + "_desc")
                {
                    SortedField = column.SortExpression;
                    SortedDirection = SortDirections.Descending;
                    SortedCurrent = column.SortExpression + "_desc";
                    SortedExpression = column.SortExpression;
                    column.SortIcon = UpIcon;
                }
                else
                {
                    column.SortIcon = default;
                }
            }
            );
        }
    }
}