using AutoMapper;
using GlobusRemote.Areas.MobileBooks.Models;
using GlobusRemote.Controllers;
using GlobusRemote.Data;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories.MobileBooks;
using GlobusRemote.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobusRemote.Areas.MobileBooks.Controllers
{
    public class FilesController : BaseController<TrsappFile>
    {
        public static MobileFilesRepository _filesRepository;
        static List<Computer> comps = new List<Computer>();

        public FilesController(MobileFilesRepository repository, IMapper mapper) : base(repository, mapper) {
            _filesRepository = repository;
            comps.Add(new Computer { Id = 1, Name = "Apple II", Company = "Apple", Year = 1977 });
            comps.Add(new Computer { Id = 2, Name = "Macintosh", Company = "Apple", Year = 1983 });
            comps.Add(new Computer { Id = 3, Name = "IBM PC", Company = "IBM", Year = 1981 });
            comps.Add(new Computer { Id = 4, Name = "Altair", Company = "MITS", Year = 1975 });
        }

        public IActionResult List(int page = 1, int perPage = 20, string sort = "", string search = "")
            => base.List<FilesItemViewModel>(page, perPage, sort, search, true);

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                var item = new FilesItemViewModel();
                return PartialView(item);
            }
            else
            {
                var data = _filesRepository.Get((long) id);
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