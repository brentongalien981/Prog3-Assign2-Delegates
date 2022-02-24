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
        HashSet<SendViaEmail> emailSubscriptionsSet = new HashSet<SendViaEmail>();
        HashSet<SendViaMobile> phoneNumSubscriptionsSet = new HashSet<SendViaMobile>();
        Publisher publisher = new Publisher();



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
            bool isEmailValid = true;
            bool isPhoneNumValid = true;
            bool didAllValidationsPass = true;


            // Reset labels.
            emailResultLabel.Text = "";
            phoneResultLabel.Text = "";
            statusLabel.Text = "";


            // Validate email.
            if (notifyByEmailCheckBox.Checked)
            {
                isEmailValid = this.validateEmail();
            }


            // Validate phoneNum.
            if (notifyBySmsCheckBox.Checked)
            {
                isPhoneNumValid = this.validatePhoneNum();
            }


            // Notify user if email is invalid.
            if (notifyByEmailCheckBox.Checked && !isEmailValid)
            {
                didAllValidationsPass = false;
                emailResultLabel.Text = "Invalid email.";
            }


            // Notify user if phoneNum is invalid.
            if (notifyBySmsCheckBox.Checked && !isPhoneNumValid)
            {
                didAllValidationsPass = false;
                phoneResultLabel.Text = "Invalid number. Should be in format: 111-222-4444";
            }


            // If there's no validation errors, proceed.
            if (didAllValidationsPass)
            {
                string newStatusLabel = "";


                // Subscribe by email
                if (notifyByEmailCheckBox.Checked)
                {
                    string email = emailTextBox.Text;

                    if (doesEmailExistInSet(email, emailSubscriptionsSet))
                    {
                        newStatusLabel += $"\nOops, {email} already exists.";
                    }
                    else
                    {
                        // Add the contact to subscriptionSet, then subscribe.
                        SendViaEmail subscriptionByEmail = new SendViaEmail(email);
                        emailSubscriptionsSet.Add(subscriptionByEmail);
                        subscriptionByEmail.Subscribe(this.publisher);

                        newStatusLabel += $"\nSuccesfully subscribed {email}!";

                    }

                }


                // Subscribe by sms.
                if (notifyBySmsCheckBox.Checked)
                {
                    string phoneNum = phoneTextBox.Text;

                    if (doesPhoneNumExistInSet(phoneNum, phoneNumSubscriptionsSet))
                    {
                        newStatusLabel += $"\nOops, {phoneNum} already exists.";
                    }
                    else
                    {
                        // Add the contact to subscriptionSet, then subscribe.
                        SendViaMobile subscriptionBySms = new SendViaMobile(phoneNum);
                        phoneNumSubscriptionsSet.Add(subscriptionBySms);
                        subscriptionBySms.Subscribe(this.publisher);

                        newStatusLabel += $"\nSuccesfully subscribed {phoneNum}!";

                    }
                }


                statusLabel.Text = newStatusLabel;
            }
        }



        private static bool doesEmailExistInSet(string email, HashSet<SendViaEmail> subscriptionSet)
        {
            foreach (var subscription in subscriptionSet)
            {
                if (subscription.EmailAddr.Equals(email))
                {
                    return true;
                }
            }

            return false;
        }



        private static bool doesPhoneNumExistInSet(string phoneNum, HashSet<SendViaMobile> subscriptionSet)
        {
            foreach (var subscription in subscriptionSet)
            {
                if (subscription.CellPhone.Equals(phoneNum))
                {
                    return true;
                }
            }

            return false;
        }



        private bool validatePhoneNum()
        {
            string phoneNum = phoneTextBox.Text;

            Regex regex = new Regex(@"^(\d{3})-(\d{3})-(\d{4})$");
            Match match = regex.Match(phoneNum);

            if (match.Success)
            {
                return true;
            }

            return false;
        }



        private bool validateEmail()
        {
            string email = emailTextBox.Text;

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (match.Success)
            {
                return true;
            }

            return false;
        }
    }
}
