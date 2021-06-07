using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CRM.UI.Controllers
{
    [Authorize(Policy = "UserAccess")]
    public class BaseController : Controller
    {
        private readonly CompanyContext _basecontext;

        public BaseController(CompanyContext context)
        {
            _basecontext = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (HttpContext.User.Claims.ToArray()[2].Value != null)
                {

                    //ViewBag["UserID"] = HttpContext.User.Claims.ToArray()[0].Value;
                    //ViewBag["UserName"] = HttpContext.User.Claims.ToArray()[1].Value;
                    //ViewBag["UserRole"] = HttpContext.User.Claims.ToArray()[2].Value;
                    ViewBag.UserID = HttpContext.User.Claims.ToArray()[0].Value;
                    ViewBag.UserName = HttpContext.User.Claims.ToArray()[1].Value;
                    ViewBag.UserRole = HttpContext.User.Claims.ToArray()[2].Value;
                    ViewBag.IsAuth = true;

                }
                else
                {
                    ViewBag.IsAuth = false;
                }
            }
            else
            {
                ViewBag.IsAuth = false;
            }
        }
    }
}
