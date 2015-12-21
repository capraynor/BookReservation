using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.DAL;
using BookReservationSystem.Entities;

namespace BookReservationSystem.Services {
    public class BookManagementService {
        private BookReservationContext DbContext;

        public BookManagementService() {
            this.DbContext = new BookReservationContext();
        }

        public List<T_Book> GetAllBooks() {
            var books = from c in this.DbContext.Books select c;
            return books.ToList();
        }

        public void GenerateOrder(string ISBN, int quantity, string orderOwner) {
            var book = (from c in DbContext.Books where c.ISBN == ISBN select c).ToList();
            if (!book.Any()) {
                throw new Exception("找不到这本书");
            }

            var currentBook = book.First();
            var relatedOrderId = new Guid ().ToString ();
            if (quantity > currentBook.Quantity) {
                var lackBooks = new T_LackBooks() {
                    ISBN = currentBook.ISBN,
                    Quantity = quantity-currentBook.Quantity,
                    Status = LackBooksStatus.Unhandled,
                    RelatedOrderId = relatedOrderId
                };

                DbContext.LackBooks.Add(lackBooks);
                
                GenerateOutOfStockOrder(ISBN, quantity, orderOwner, relatedOrderId );
                DbContext.SaveChanges ();
                throw new Exception ( $"该书库存不足 ISBN：{ISBN} 书名：{currentBook.Title}" );
            }
            else {
                //减少库存
                currentBook.Quantity -= quantity;
                DbContext.Books.Attach(currentBook);
                var bookEntry = DbContext.Entry(currentBook);
                bookEntry.Property(e => e.Quantity).IsModified = true;

                //新建一个订单
                var order = new T_Order() {
                    OrderOwner = orderOwner,
                    ISBN = ISBN,
                    Quantity = quantity,
                    Status = OrderStatus.Unhandled
                    
                };
                DbContext.Orders.Add(order);


                DbContext.SaveChanges();
            }
        }


        /// <summary>
        /// 生成缺书订单
        /// </summary>
        /// <param name="ISBN"></param>
        /// <param name="quantity"></param>
        /// <param name="orderOwner"></param>
        /// <param name="orderId"></param>
        private void GenerateOutOfStockOrder(string ISBN, int quantity, string orderOwner, string orderId) {
            var order = new T_Order () {
                OrderOwner = orderOwner,
                ISBN = ISBN,
                Quantity = quantity,
                Status = OrderStatus.OutOfStock

            };
            DbContext.Orders.Add ( order );


            DbContext.SaveChanges ();
        }
    }
}