using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupRepository repository;

        public GroupsController(IGroupRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
