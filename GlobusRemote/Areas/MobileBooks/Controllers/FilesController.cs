using AutoMapper;
using GlobusRemote.Areas.MobileBooks.Models;
using GlobusRemote.Controllers;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories.MobileBooks;
using GlobusRemote.Models;
using GlobusRemote.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;

namespace GlobusRemote.Areas.MobileBooks.Controllers
{
    [Area("MobileBooks")]
    public class FilesController : BaseController<TrsappFile>
    {
        public static MobileFilesRepository _filesRepository;
        public static MobileDirFilesTypesRepository _dirFilesTypesRepository;

        public FilesController(MobileFilesRepository repository,
            MobileDirFilesTypesRepository dirFilesTypesRepository,
            IMapper mapper) : base(repository, mapper) {
            _filesRepository = repository;
            _dirFilesTypesRepository = dirFilesTypesRepository;
        }

        public IActionResult List(int page = 1, int perPage = 20, string sort = "", string search = "")
            => base.List<FilesItemViewModel>(page, perPage, sort, search, true);

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                var item = new FilesEditViewModel();
                return GetViewUpdated(item);
            }
            else
            {
                var data = _filesRepository.Get((long) id);
                if (data != null)
                {
                    var item = _mapper.Map<FilesEditViewModel>(data);
                    return GetViewUpdated(item);
                }
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilesEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return GetViewUpdated(viewModel);
            }

            var entity = _mapper.Map<FilesEditViewModel, TrsappFile>(viewModel);

            if (viewModel.File != null)
            {
                entity.Fbody = FileHelper.GetBody(viewModel.File);
            }
            else
            {
                _filesRepository.SetPropertyUnModified(entity, "Fbody");
            }

            try
            {
                _filesRepository.Save(entity);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    throw;
                }
                else if (ex.InnerException.Message.Contains("UK_RSAppFiles_Name"))
                {
                    ModelState.AddModelError(nameof(FilesEditViewModel.Fname), Localize.Index.Error_DB_UK_RSAppFiles_Name);
                    return GetViewUpdated(viewModel);
                }
                else
                {
                    throw;
                }
            }            

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(long id)
        {
            var item = _filesRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            _filesRepository.Remove(item);
            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Show(long id)
        {
            var item = _filesRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            var fileName = $"{item.Fname}.{item.Fextention}";
            new FileExtensionContentTypeProvider()
                .TryGetContentType(fileName, out string contentType);
            return File(item.Fbody, contentType, fileName);
        }

        public override bool CanAdd() => true;

        protected ActionResult GetViewUpdated(FilesEditViewModel item)
        {
            item.Types = _dirFilesTypesRepository.GetTypes();
            return PartialView(item);
        }

        protected override void FillItemViewModel(List<TrsappFile> data, BaseItemViewModel item)
        {
            item.EditInfo.Id = (item as FilesItemViewModel).Fid.ToString();
            item.EditInfo.CanShow = true;
            item.EditInfo.CanEdit = true;
            item.EditInfo.CanDelete = true;
        }

        protected override void FillHeaderModel(HeaderViewModel model)
        {
            model.AddColumn(Localize.Index.Field_Base_Id, "Fid");
            model.AddColumn(Localize.Index.Field_Base_Type, "FtypeName", false);
            model.AddColumn(Localize.Index.Field_Base_Name, "Fname");
            model.AddColumn(Localize.Index.Field_Base_Extention, "Fextention");
            model.AddColumn(Localize.Index.Field_Base_Size, "FsizeInKb");
            model.AddColumn(Localize.Index.Field_Base_DateCreated, "FdateCreated");
            model.AddColumn(Localize.Index.Field_Base_DateChanged, "FdateChanged");
        }
    }
}