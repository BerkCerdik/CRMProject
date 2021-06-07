using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace CRM.UI.Controllers
{
    public class HRController : BaseController
    {

        private readonly CompanyContext _basecontext;

        public HRController(CompanyContext context) : base(context)
        {
            _basecontext = context;
        }

        public IActionResult OffDayAsk()
        {
            var employee = _basecontext.Employees.ToList();

            return View();
        }
    }
}
