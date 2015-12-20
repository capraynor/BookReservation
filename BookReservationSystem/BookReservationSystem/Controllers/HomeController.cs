using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReservationSystem.Entities;
using BookReservationSystem.Models;
using BookReservationSystem.Services;

namespace BookReservationSystem.Controllers {
    public class HomeController : Controller {
        private BookManagementService _bookManagementService;
        private OrderManagementService _orderManagementService;
        private NotificationService _notificationService;
        private string _distributionManagerEmail = @"distribution@example.org";

        public HomeController() {
            _orderManagementService = new OrderManagementService();
            this._bookManagementService = new BookManagementService();
            this._notificationService = new NotificationService();
        }

        public ActionResult Index ( ) {
            return View ();
        }
        /// <summary>
        /// 教师或者学生的Action
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult TeacherOrStudent() {
            var isLogin = (Session["IsLogin"] != null);
            if (!(bool)isLogin) {
                return RedirectToActionPermanent ( "Login", "Account" );
            }
            var currentUser = Session["CurrentUser"] as T_User;
            
            this.ViewBag.CurrentUser = currentUser;
            this.ViewBag.IsLogin = isLogin;
            var teacherOrStudentViewModel = new TeacherOrStudentViewModel {
                CurrentUser = currentUser,
                BookList = this._bookManagementService.GetAllBooks(),
                OrderList = this._orderManagementService.GetOrdersByUser(currentUser.Email)
                
            };

            return View( teacherOrStudentViewModel );
        }

        [HttpPost]
        public ActionResult SubmitOrder(string ISBN, int quantity) {
            var currentUser = Session["CurrentUser"] as T_User;

            var currentEmail = currentUser.Email;
            try {
                _bookManagementService.GenerateOrder ( ISBN, quantity, currentEmail );
            }
            catch (Exception exception) {

                return Json ( new {
                    Success = false,
                    Message = "订单提交失败 原因：" + exception.Message
                } );
            }
            return Json(new {
                Success = true,
                Message = "订单提交成功 请等待工作人员审核"
            });
        }

        /// <summary>
        /// 采购员的Action
        /// </summary>
        /// <returns></returns>
        public ActionResult PurchaseManagement() {
            var isLogin = (Session["IsLogin"] != null);
            if (!(bool)isLogin) {
                return RedirectToActionPermanent ( "Login", "Account" );
            }
            var currentUser = Session["CurrentUser"] as T_User;
            
            this.ViewBag.CurrentUser = currentUser;
            this.ViewBag.IsLogin = isLogin;
            return View();
        }
        /// <summary>
        /// 分发管理员的Action
        /// </summary>
        /// <returns></returns>
        public ActionResult DistributionManagement() {
            var isLogin = (Session["IsLogin"] != null);
            if (!(bool)isLogin) {
                return RedirectToActionPermanent ( "Login", "Account" );
            }
            var currentUser = Session["CurrentUser"] as T_User;
            
            this.ViewBag.CurrentUser = currentUser;
            this.ViewBag.IsLogin = isLogin;
            return View();
        }

        public ActionResult About ( ) {
            ViewBag.Message = "Your application description page.";

            return View ();
        }

        public ActionResult Contact ( ) {
            ViewBag.Message = "Your contact page.";

            return View ();
        }
    }
}