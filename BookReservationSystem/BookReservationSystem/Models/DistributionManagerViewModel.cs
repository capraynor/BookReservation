using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.Entities;

namespace BookReservationSystem.Models {
    public class DistributionManagerViewModel {
        public List<T_Order> UnhandledOrders;
        public List<T_Book> Books;
    }
}