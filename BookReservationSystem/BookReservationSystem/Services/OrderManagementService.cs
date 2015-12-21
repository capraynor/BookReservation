using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public List<T_Order> GetAllUnhandledOrders() {
            var orders = (from c in DbContext.Orders where c.Status != OrderStatus.Completed select c).ToList();
            return orders;
        }

        /// <summary>
        /// 分发管理员批准分发
        /// </summary>
        /// <param name="orderId"></param>
        public void StartDistribute(int orderId) {
            var currentOrder = (from c in DbContext.Orders where c.Id == orderId select c).ToList().First();
            currentOrder.Status = OrderStatus.AwaitingDelivery;
            DbContext.Orders.Attach(currentOrder);
            var orderEntry = DbContext.Entry(currentOrder);
            orderEntry.Property(e => e.Status).IsModified = true;
            DbContext.SaveChanges();
        }

        public void StartPurchase(int orderId) {
            var currentOrder = (from c in DbContext.Orders where c.Id == orderId select c).ToList ().First ();
        }

        public List<T_LackBooks> GetAllLackBooks() {
            return (from c in DbContext.LackBooks where c.Status != LackBooksStatus.Completed select c).ToList();

        }


        public void FinishedPurchase(int lackBooksId) {
            var currentLackBook = (from c in DbContext.LackBooks where c.Id == lackBooksId select c).ToList().First();
            currentLackBook.Status = LackBooksStatus.Completed;
            var currentOrderGuid = currentLackBook.RelatedOrderId;

            var currentOrder =
                (from c in DbContext.Orders where c.OrderId == currentOrderGuid select c).ToList().First();
            currentOrder.Status = OrderStatus.AwaitingDelivery;;


            DbContext.Orders.Attach(currentOrder);
            DbContext.LackBooks.Attach(currentLackBook);

            var orderEntry = DbContext.Entry(currentOrder);
            var lackBookEntry = DbContext.Entry(currentLackBook);

            orderEntry.Property(x => x.Status).IsModified = true;
            lackBookEntry.Property(x => x.Status).IsModified = true;

            DbContext.SaveChanges();
        }
    }
}