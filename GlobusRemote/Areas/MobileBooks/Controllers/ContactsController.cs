using AutoMapper;
using GlobusRemote.Areas.MobileBooks.Models;
using GlobusRemote.Controllers;
using GlobusRemote.Data.Const;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories.MobileBooks;
using GlobusRemote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.MobileBooks.Controllers
{
    [Area("MobileBooks")]
    public class ContactsController : BaseController<TrsdirAppContact>
    {
        //public static MobileContactsRepository СontactsRepository { get; } = (MobileContactsRepository) _repository;

        public ContactsController(MobileContactsRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IActionResult List(int page = 1, int perPage = 20, string sort = "", string search = "")
            => base.List<ContactsItemViewModel>(page, perPage, sort, search);

        protected override void FillHeaderModel(HeaderViewModel model)
        {            
            model.AddColumn(Localize.Index.Field_Base_Id, "Fid");
            model.AddColumn(Localize.Index.Field_Base_Name, "Fname");
            model.AddColumn(Localize.Index.Field_Base_Phone, "ContactsLinks", false);
            model.AddColumn(Localize.Index.Field_Base_Code, "Fcode");
            model.AddColumn(Localize.Index.Field_Base_Comment, "Fcomment");
            model.AddColumn(Localize.Index.Field_Base_FlagExpire, "FflagExpire");
            model.AddColumn(Localize.Index.Field_Base_DateCreated, "FdateCreated");
            model.AddColumn(Localize.Index.Field_Base_DateChanged, "FdateChanged");
        }

        //protected override void GetData()
        //{
        //    var data = _repository.GetWithParams(1, 1, "", SortDirections.Ascending, "");

        //    for (var i = 0; i < data.Count; i++)
        //    {
        //        var contact = data[i];
        //        //var val1 = contact.TrsdirAppContactsLink;
        //        var val = contact.TrsdirAppContactsLinks.Count;
                
        //    }
        //}
    }
}