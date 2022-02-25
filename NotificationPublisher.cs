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
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void publishBtn_Click(object sender, EventArgs e)
        {
            TheSubscriptionManager theSubscriptionManager = TheSubscriptionManager.getSingletonInstance();

            string msg = notificationContentTextBox.Text;

            if (string.IsNullOrEmpty(msg))
            {
                statusLabel.Text = "Notification content can't be empty.";
            }
            else
            {
                theSubscriptionManager.publisher.PublishMessage(msg);
            }
            
        }
    }
}
