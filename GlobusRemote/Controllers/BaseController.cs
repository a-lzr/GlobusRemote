using AutoMapper;
using GlobusRemote.Data.Const;
using GlobusRemote.Data.Entities;
using GlobusRemote.Data.Repositories;
using GlobusRemote.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobusRemote.Controllers
{
    [Authorize]
    public abstract class BaseController<Entity> : Controller
        where Entity : BaseEntity
    {
        protected static BaseRepository<Entity> _repository;
        protected IMapper _mapper;

        public BaseController(BaseRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int CalcCountPages(int count, int perPage)
            => (int)Math.Ceiling((decimal)count / perPage);

        public virtual bool CanAdd() => false;

        public IActionResult List<ItemModel>(int page, int perPage, string sort, string search, bool fillItemsCustom = false)
            where ItemModel : BaseItemViewModel
        {
            var header = new HeaderViewModel();
            FillHeaderModel(header);
            header.ApplySort(sort);

            var count = _repository.Count(header.SortedField, header.SortedDirection, search);
            var pagesCount = CalcCountPages(count, perPage);
            if (page < 1)
            {
                return RedirectToAction("List", new { page = 1 });
            }
            else if(page > pagesCount && pagesCount > 0)
            {
                return RedirectToAction("List", new { page = pagesCount });
            }

            var data = _repository.GetWithParams(page, perPage, header.SortedField, header.SortedDirection, search);

            var model = new BaseListViewModel<ItemModel>()
            {
                Page = page,
                RecordPerPage = perPage,
                TotalRecordCount = count,
                PagesCount = pagesCount,
                Search = search,
                Header = header,
                Items = _mapper.Map<List<ItemModel>>(data),
                CanAdd = CanAdd()
            };
                
            if (fillItemsCustom)
            {
                model.Items.ForEach(item => FillItemViewModel(data, item));
            }

            return View(model);
        }

        protected abstract void FillHeaderModel(HeaderViewModel model);

        protected virtual void FillItemViewModel(List<Entity> data, BaseItemViewModel item)
        {
            item.EditInfo.CanEdit = false;
            item.EditInfo.CanDelete = false;
        }

        //protected abstract void GetData();
    }
}
