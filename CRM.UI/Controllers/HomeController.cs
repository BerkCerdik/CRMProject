using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace CRM.UI.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(CompanyContext context) : base(context)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
