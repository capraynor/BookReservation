using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.DAL;
using BookReservationSystem.Entities;

namespace BookReservationSystem.Services {
    public class OrderManagementService {
        private BookReservationContext DbContext;

        public OrderManagementService() {
            this.DbContext = new BookReservationContext();
        }


        public List<T_Order> GetOrdersByUser(string email) {
            var orders = (from c in DbContext.Orders where c.OrderOwner == email select c).ToList();
            return orders;
        }
    }
}