using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrenBaga_Lab2
{
    public partial class NotificationPublisher : Form
    {
        public NotificationPublisher()
        {
            InitializeComponent();

            // Set the notification-display-manager to reference this window.
            NotificationsDisplayManager.SetNotificationPublisherWindow(this);

        }



        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void publishBtn_Click(object sender, EventArgs e)
        {
            // Reference theSubscriptionManager.
            TheSubscriptionManager theSubscriptionManager = TheSubscriptionManager.getSingletonInstance();

            string msg = notificationContentTextBox.Text;

            // Show messages.
            if (string.IsNullOrEmpty(msg))
            {
                statusLabel.Text = "Notification content can't be empty.";
            }
            else
            {
                NotificationsDisplayManager.ResetNotifications();
                theSubscriptionManager.publisher.PublishMessage(msg);
            }
            
        }



        internal void RefreshNotificationDisplay(List<string> notifications)
        {
            string allNotificationsStr = "";

            foreach (var n in notifications)
            {
                allNotificationsStr += n + "\n";
            }

            statusLabel.Text = allNotificationsStr;
        }
    }
}
