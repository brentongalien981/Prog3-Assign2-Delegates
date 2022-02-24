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
            statusLabel.Text = "";

            emailResultLabel.ForeColor = Color.Red;
            phoneResultLabel.ForeColor = Color.Red;


            // Process email.
            if (notifyByEmailCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = TheSubscriptionManager.ProcessSubscription("email", emailTextBox.Text);

                // If email is subscribed.
                if (subscriptionResult.IsSuccessful)
                {
                    emailResultLabel.ForeColor = Color.Green;                    
                }

                emailResultLabel.Text = subscriptionResult.ResultMsg;
            }


            // Process mobile.
            if (notifyBySmsCheckBox.Checked)
            {
                SubscriptionResult subscriptionResult = TheSubscriptionManager.ProcessSubscription("mobile", phoneTextBox.Text);

                // If mobile is subscribed.
                if (subscriptionResult.IsSuccessful)
                {
                    phoneResultLabel.ForeColor = Color.Green;
                }

                phoneResultLabel.Text = subscriptionResult.ResultMsg;
            }


        }



        //private static SendViaEmail? getEmailSubscriptionFromSet(string email, HashSet<SendViaEmail> subscriptionSet)
        //{
        //    foreach (var subscription in subscriptionSet)
        //    {
        //        if (subscription.EmailAddr.Equals(email))
        //        {
        //            return subscription;
        //        }
        //    }

        //    return null;
        //}



        //private static SendViaMobile? getSmsSubscriptionFromSet(string phoneNum, HashSet<SendViaMobile> subscriptionSet)
        //{
        //    foreach (var subscription in subscriptionSet)
        //    {
        //        if (subscription.CellPhone.Equals(phoneNum))
        //        {
        //            return subscription;
        //        }
        //    }

        //    return null;
        //}



        private void unsubscribeBtn_Click(object sender, EventArgs e)
        {
            //    // Reset labels.
            //    emailResultLabel.Text = "";
            //    phoneResultLabel.Text = "";
            //    statusLabel.Text = "";


            //    string newStatusLabel = "";


            //    // Unsubscribe by email
            //    if (notifyByEmailCheckBox.Checked)
            //    {
            //        string email = emailTextBox.Text;

            //        if (doesEmailExistInSet(email, emailSubscriptionsSet))
            //        {
            //            // Unsubscribe the contact, then remove from subscriptionSet.
            //            SendViaEmail? subscriptionByEmail = getEmailSubscriptionFromSet(email, emailSubscriptionsSet);

            //            subscriptionByEmail?.Unsubscribe(this.publisher);
            //            emailSubscriptionsSet.RemoveWhere(subscription => subscription.EmailAddr.Equals(email));

            //            newStatusLabel += $"\nSuccesfully unsubscribed {email}!";
            //        }
            //        else
            //        {
            //            newStatusLabel += $"\nOops, {email} does not exist.";

            //        }

            //    }


            //    // Unsubscribe by sms
            //    if (notifyBySmsCheckBox.Checked)
            //    {
            //        string phoneNum = phoneTextBox.Text;

            //        if (doesPhoneNumExistInSet(phoneNum, phoneNumSubscriptionsSet))
            //        {
            //            // Unsubscribe the contact, then remove from subscriptionSet.
            //            SendViaMobile? subscriptionBySms = getSmsSubscriptionFromSet(phoneNum, phoneNumSubscriptionsSet);

            //            subscriptionBySms?.Unsubscribe(this.publisher);
            //            phoneNumSubscriptionsSet.RemoveWhere(subscription => subscription.CellPhone.Equals(phoneNum));

            //            newStatusLabel += $"\nSuccesfully unsubscribed {phoneNum}!";
            //        }
            //        else
            //        {
            //            newStatusLabel += $"\nOops, {phoneNum} does not exist.";

            //        }

            //    }


            //    statusLabel.Text = newStatusLabel;
        }
    }
}
