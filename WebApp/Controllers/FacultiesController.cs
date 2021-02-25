using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class FacultiesController : Controller
    {
        IFacultyRepository _reposutory;

        public FacultiesController(IFacultyRepository reposutory)
        {
            _reposutory = reposutory;
        }

        //[Authorize(Policy = "RequireModerator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
