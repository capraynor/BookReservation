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
        private readonly LoginService _loginService;

        public AccountController() {
            this._loginService = new LoginService();
        }
        [HttpGet]
        public ActionResult Login() {
            this.ViewBag.Message = "请先登录";
            return View();
        }

        [HttpPost]
        public ActionResult Login(string inputEmail,string inputPassword) {
            var user = _loginService.CheckLogin(inputEmail, inputPassword);
            if (user == null) {
                this.ViewBag.Message = "登录失败";
                return View();
            }
            this.Session["CurrentUser"] = user;
            this.Session["IsLogin"] = true;
            switch (user.Role) {
                case UserRole.TeacherOrStudent: {
                    return RedirectToActionPermanent ( "TeacherOrStudent", "Home" );
                }
                case UserRole.DistributionManager: {
                    return RedirectToActionPermanent ( "DistributionManagement", "Home" );
                }
                case UserRole.Buyer: {
                    return RedirectToActionPermanent( "PurchaseManagement", "Home" );
                }
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.ViewBag.Message = "登录失败";
            return View ();
        }
    }
}