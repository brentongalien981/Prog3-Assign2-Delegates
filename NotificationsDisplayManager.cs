using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class NotificationsDisplayManager
    {
        private static List<string> notifications = new List<string>();
        private static NotificationPublisher notificationPublisherWindow;



        public static void ResetNotifications()
        {
            notifications.Clear();
        }



        public static void SetNotificationPublisherWindow(NotificationPublisher theWindow)
        {
            notificationPublisherWindow = theWindow;
        }



        public static void DisplayNotification(string msg)
        {
            notifications.Add(msg);
            notificationPublisherWindow.RefreshNotificationDisplay(notifications);
        }
    }
}
