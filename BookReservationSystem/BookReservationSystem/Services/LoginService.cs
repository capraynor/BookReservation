using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.Entities;
using BookReservationSystem.DAL;
namespace BookReservationSystem.Services {
    public class LoginService {
        private BookReservationContext DbContext;
        
        public LoginService() {
            this.DbContext = new BookReservationContext();
            
        }

        public T_User GetUserPassword(string email, string password) {
            var User = from user in this.DbContext.Users where user.Email == email select user;

            return User.First();
        }
    }
}