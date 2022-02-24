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


            if (didAllValidationsPass)
            {
                // Subscribe by email
                if (notifyByEmailCheckBox.Checked)
                {
                    // TODO: Subscribe
                    string email = emailTextBox.Text;

                    // 
                    statusLabel.Text = $"Succesfully subscribed {email}!";
                }


                // Subscribe by sms.
                if (notifyBySmsCheckBox.Checked)
                {
                    // TODO: Subscribe
                    string phoneNum = phoneTextBox.Text;

                    // 
                    statusLabel.Text += $"\nSuccesfully subscribed {phoneNum}!";
                }
            }
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
