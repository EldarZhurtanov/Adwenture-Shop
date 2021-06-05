using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using Web.UserServiceReference;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserServiceApadterForOwinContext>(); //HttpContext.GetOwinContext().GetUserManager<IUserService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password};
                ClaimsIdentity claim = UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Password = model.Password,
                    AddressLine1 = model.AddressLine1,
                    AddressStateProvinceID = model.AddressStateProvinceID,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Role = "user"
                };
                OperationDetailsDTO operationDetails = UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}