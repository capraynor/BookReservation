using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookReservationSystem.DAL;
using BookReservationSystem.Entities;

namespace BookReservationSystem.Services {
    public class NotificationService {
        private BookReservationContext DbContext;

        public NotificationService() {
            DbContext = new BookReservationContext();
        }

        public void SendNotification(string from, string to, string content, NotificationStatus status) {
            var notification = new T_Notification() {
                From = from,
                To = to,
                Content = content,
                Status = status
            };

            DbContext.Notifications.Add(notification);
            DbContext.SaveChanges();

        }
    }
}