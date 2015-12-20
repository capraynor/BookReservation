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

            

            foreach (var user in User) {
                Console.WriteLine(user.Email);
            }
            return User.ToList().First();
        }

        public T_User CheckLogin(string email, string password) {
            var user = from c in this.DbContext.Users where c.Email == email select c;
            if (!user.Any()) {
                return null;
            }

            return user.First().Password != password ? null : user.First();
        }
    }
}