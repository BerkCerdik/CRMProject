using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using CRM.Data.Context;
using CRM.Services.Dto;



namespace CRM.UI.Controllers
{
    public class LoginController : Controller
    {

        private readonly CompanyContext _context;

        public LoginController(CompanyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                //var fullname = "Avni Özdamar";
                //var password = "saros1303";
                var employee = _context.Employees.FirstOrDefault(x => x.FullName == model.Username && x.Password == model.Password && x.IsDeleted == false);

                if (employee != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, employee.Id.ToString()),
                        new Claim(ClaimTypes.Name,employee.FullName),
                        new Claim(ClaimTypes.UserData,employee.Role)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync("UserScheme", principal);


                    if (HttpContext.User.Identity.IsAuthenticated)
                    {
                        if (HttpContext.User.Claims.ToArray()[2].Value != null)
                        {
                            TempData["UserID"] = HttpContext.User.Claims.ToArray()[0].Value;
                            TempData["UserName"] = HttpContext.User.Claims.ToArray()[1].Value;
                            TempData["UserRole"] = HttpContext.User.Claims.ToArray()[2].Value;
                        }

                    }

                    _context.SaveChanges();

                    return Redirect("/Home/Index");

                }
                else
                {
                    ViewBag.error = "E-Mail or Password wrong!";
                    return View();
                }

            }
            else
            {
                return View();
            }

        }
    }
}
