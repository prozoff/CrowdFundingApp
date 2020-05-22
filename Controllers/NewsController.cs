using CrowdFundingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingApp.Controllers
{
    public class NewsController : Controller
    {
        ApplicationContext db;

        public NewsController(ApplicationContext context)
        {
            db = context;
        }


    }
}
