using AutoMapper;
using GlobusRemote.Areas.Admin.Models;
using GlobusRemote.Data.Repositories.Custom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.Admin.Controllers
{
    public class OperatorsTemplatesController : Controller
    {
        private OperatorsTemplatesRepository _repository;
        private IMapper _mapper;

        public OperatorsTemplatesController(
            OperatorsTemplatesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data= _repository.GetAll();
            var model = _mapper.Map<List<OperatorsTemplatesListViewModel>>(data);

            foreach (var item in model)
            {
                item.CanEdit = true;
            }

            return View(model);
        }
    }
}