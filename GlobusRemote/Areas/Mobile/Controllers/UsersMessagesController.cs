using AutoMapper;
using GlobusRemote.Areas.Mobile.Models;
using GlobusRemote.Data.Repositories.Mobile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlobusRemote.Areas.Mobile.Controllers
{
    [Area("Mobile")]
    public class UsersMessagesController : Controller
    {
        private MobileUsersMessagesRepository _repository;
        private IMapper _mapper;

        public UsersMessagesController(
            MobileUsersMessagesRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var data = _repository.GetAll();
            var model = _mapper.Map<List<UsersMessagesListViewModel>>(data);

            foreach (var item in model)
            {
                item.CanEdit = true;
            }

            return View(model);
        }
    }
}