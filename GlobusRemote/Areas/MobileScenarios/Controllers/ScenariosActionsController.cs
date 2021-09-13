using AutoMapper;
using GlobusRemote.Areas.MobileScenarios.Models;
using GlobusRemote.Data.Repositories.MobileScenarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.MobileScenarios.Controllers
{
    public class ScenariosActionsController : Controller
    {
        private MobileScenariosActionsRepository _repository;
        private IMapper _mapper;

        public ScenariosActionsController(
            MobileScenariosActionsRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data= _repository.GetAll();
            var model = _mapper.Map<List<ScenariosActionsListViewModel>>(data);

            foreach (var item in model)
            {
                item.CanEdit = true;
            }

            return View(model);
        }
    }
}