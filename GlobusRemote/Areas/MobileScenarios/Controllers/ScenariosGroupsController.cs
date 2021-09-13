using AutoMapper;
using GlobusRemote.Areas.MobileScenarios.Models;
using GlobusRemote.Data.Repositories.MobileScenarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.MobileScenarios.Controllers
{
    public class ScenariosGroupsController : Controller
    {
        private MobileScenariosGroupsRepository _repository;
        private IMapper _mapper;

        public ScenariosGroupsController(
            MobileScenariosGroupsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data= _repository.GetAll();
            var model = _mapper.Map<List<ScenariosGroupsListViewModel>>(data);

            foreach (var item in model)
            {
                item.CanEdit = true;
            }

            return View(model);
        }
    }
}