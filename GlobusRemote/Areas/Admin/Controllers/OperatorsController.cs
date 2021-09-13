using AutoMapper;
using GlobusRemote.Areas.Admin.Models;
using GlobusRemote.Data.Repositories.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.Admin.Controllers
{
    public class OperatorsController : Controller
    {
        private OperatorsRepository _repository;
        private IMapper _mapper;

        public OperatorsController(
            OperatorsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data = _repository.GetAll();
            var model = _mapper.Map<List<OperatorsListViewModel>>(data);

            foreach (var item in model)
            {
                item.CanEdit = true;
            }

            return View(model);
        }
    }
}