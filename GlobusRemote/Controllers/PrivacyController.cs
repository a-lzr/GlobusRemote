using AutoMapper;
using GlobusRemote.Areas.MobileBooks.Models;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories.MobileBooks;
using GlobusRemote.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobusRemote.Controllers
{

    public class PrivacyController : BaseController<TrsappFile>
    {
        public static MobileFilesRepository _filesRepository;

        public PrivacyController(MobileFilesRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _filesRepository = repository;
        }

        public IActionResult List(int page = 1, int perPage = 20, string sort = "", string search = "")
            => base.List<FilesItemViewModel>(page, perPage, sort, search, true);

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                var item = new FilesItemViewModel();
                return PartialView(item);
            }
            else
            {
                var data = _filesRepository.Get((long)id);
                if (data != null)
                {
                    var item = _mapper.Map<FilesItemViewModel>(data);
                    return PartialView(item);
                }
                return NotFound();
            }
        }

        public override bool CanAdd() => true;

        protected override void FillItemViewModel(List<TrsappFile> data, BaseItemViewModel item)
        {
            item.EditInfo.Id = (item as FilesItemViewModel).Fid.ToString();
            item.EditInfo.CanShow = false;
            item.EditInfo.CanEdit = true;
            item.EditInfo.CanDelete = true;
        }

        protected override void FillHeaderModel(HeaderViewModel model)
        {
            model.AddColumn(Localize.Index.Field_Base_Id, "Fid");
            model.AddColumn(Localize.Index.Field_Base_Type, "FtypeName", false);
            model.AddColumn(Localize.Index.Field_Base_Name, "Fname");
            model.AddColumn(Localize.Index.Field_Base_Extention, "Fextention");
            model.AddColumn(Localize.Index.Field_Base_Size, "Fsize");
            model.AddColumn(Localize.Index.Field_Base_DateCreated, "FdateCreated");
            model.AddColumn(Localize.Index.Field_Base_DateChanged, "FdateChanged");
        }
    }
}
