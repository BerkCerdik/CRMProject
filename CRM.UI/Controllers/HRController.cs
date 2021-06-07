using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CRM.UI.Controllers
{
    public class HRController : Controller
    {
        public IActionResult OffDayAsk()
        {
            return View();
        }
    }
}
