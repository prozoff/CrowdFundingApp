using CrowdFundingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationContext db;

        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index() => View();
    }
}
