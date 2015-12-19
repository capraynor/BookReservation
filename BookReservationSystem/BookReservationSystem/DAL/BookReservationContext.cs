using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using BookReservationSystem.Entities;

namespace BookReservationSystem.DAL {
    
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class BookReservationContext:DbContext {
        public BookReservationContext() : base("BookReservationContext") {
        }

        public DbSet<T_User> Users { get; set; }
        public DbSet<T_Book> Books { get; set; }
        public DbSet<T_BookToBePurchased> BookToBePurchased { get; set; }
        public DbSet<T_LackBooks> LackBooks { get; set; }
        public DbSet<T_Notification> Notifications { get; set; }
        public DbSet<T_Order> Orders { get; set; }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder ) {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention> ();
        }

    }
}