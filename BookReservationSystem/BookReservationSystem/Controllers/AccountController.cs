using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookReservationSystem.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BookReservationSystem.Models;
using BookReservationSystem.Services;

namespace BookReservationSystem.Controllers
{
   
    
    public class AccountController : Controller {
        private LoginService _loginService;

        public AccountController() {
            this._loginService = new LoginService();
        }
        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string inputEmail,string inputPassword) {

            return RedirectToActionPermanent("Index", "Home");
        }
    }
}