using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrenBaga_Lab2
{
    public partial class ManageSubscriptionForm : Form
    {

        public ManageSubscriptionForm()
        {
            InitializeComponent();
        }



        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void subscribeBtn_Click(object sender, EventArgs e)
        {
            // Reset labels.
            emailResultLabel.Text = "";
            phoneResultLabel.Text = "";

            emailResultLabel.ForeColor = Color.Red;
            phoneResultLabel.ForeColor = Color.Red;

            // 
            TheSubscriptionManager theSubscriptionManager = TheSubscriptionManager.getSingletonInstance();


            // Process email.
            if (notifyByEmailCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = theSubscriptionManager.ProcessSubscription("email", emailTextBox.Text);

                // If email is subscribed ok.
                if (subscriptionResult.IsSuccessful)
                {
                    emailResultLabel.ForeColor = Color.Green;                    
                }

                emailResultLabel.Text = subscriptionResult.ResultMsg;
            }


            // Process mobile.
            if (notifyBySmsCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = theSubscriptionManager.ProcessSubscription("mobile", phoneTextBox.Text);

                // If mobile is subscribed ok.
                if (subscriptionResult.IsSuccessful)
                {
                    phoneResultLabel.ForeColor = Color.Green;
                }

                phoneResultLabel.Text = subscriptionResult.ResultMsg;
            }


        }



        private void unsubscribeBtn_Click(object sender, EventArgs e)
        {
            // Reset labels.
            emailResultLabel.Text = "";
            phoneResultLabel.Text = "";

            emailResultLabel.ForeColor = Color.Red;
            phoneResultLabel.ForeColor = Color.Red;

            // 
            TheSubscriptionManager theSubscriptionManager = TheSubscriptionManager.getSingletonInstance();


            // Unsubscribe email.
            if (notifyByEmailCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = theSubscriptionManager.ProcessUnsubscription("email", emailTextBox.Text);

                // If unsubscription is ok.
                if (subscriptionResult.IsSuccessful)
                {
                    emailResultLabel.ForeColor = Color.Green;
                }

                emailResultLabel.Text = subscriptionResult.ResultMsg;
            }


            // Unsubscribe mobile.
            if (notifyBySmsCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = theSubscriptionManager.ProcessUnsubscription("mobile", phoneTextBox.Text);

                // If unsubscription is ok.
                if (subscriptionResult.IsSuccessful)
                {
                    phoneResultLabel.ForeColor = Color.Green;
                }

                phoneResultLabel.Text = subscriptionResult.ResultMsg;
            }



        }
    }
}
