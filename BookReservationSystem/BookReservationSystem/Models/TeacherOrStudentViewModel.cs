using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.Entities;

namespace BookReservationSystem.Models {
    public class TeacherOrStudentViewModel {
        public T_User CurrentUser;
        public List<T_Book> BookList;
        public List<T_Order> OrderList;
    }
}