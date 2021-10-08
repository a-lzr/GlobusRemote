using System.Collections.Generic;

namespace GlobusRemote.Models
{
    public class BaseListViewModel<ItemModel>
        where ItemModel : BaseItemViewModel
    {
        public int Page { get; set; }
        public int RecordPerPage { get; set; }
        public int TotalRecordCount { get; set; }
        public int PagesCount { get; set; }
        public int PreviousPage
        {
            get
            {
                return Page - 1;
            }
        }
        public int NextPage
        {
            get
            {
                return Page + 1;
            }
        }
        public HeaderViewModel Header { get; set; }
        public List<ItemModel> Items { get; set; }
        public string Search { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
