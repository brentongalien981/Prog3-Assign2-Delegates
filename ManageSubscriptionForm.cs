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
            resetLabels();


            // Subscribe email.
            if (notifyByEmailCheckBox.Checked)
            {
                processAction("subscribe", "email", emailTextBox.Text, emailResultLabel);
            }


            // Subscribe mobile.
            if (notifyBySmsCheckBox.Checked)
            {
                processAction("subscribe", "mobile", phoneTextBox.Text, phoneResultLabel);
            }

        }



        private void unsubscribeBtn_Click(object sender, EventArgs e)
        {
            resetLabels();


            // Unsubscribe email.
            if (notifyByEmailCheckBox.Checked)
            {
                processAction("unsubscribe", "email", emailTextBox.Text, emailResultLabel);
            }


            // Unsubscribe mobile.
            if (notifyBySmsCheckBox.Checked)
            {
                processAction("unsubscribe", "mobile", phoneTextBox.Text, phoneResultLabel);
            }

        }



        private void resetLabels()
        {
            emailResultLabel.Text = "";
            phoneResultLabel.Text = "";

            emailResultLabel.ForeColor = Color.Red;
            phoneResultLabel.ForeColor = Color.Red;
        }



        private void processAction(string processType, string contactType, string contact, Label resultLabel)
        {
            // Reference theSubscriptionManager.
            TheSubscriptionManager theSubscriptionManager = TheSubscriptionManager.getSingletonInstance();

            SubscriptionResult processResult;

            if (processType.Equals("subscribe"))
            {
                // Subscribe.
                processResult = theSubscriptionManager.ProcessSubscription(contactType, contact);
            }
            else
            {
                // Unsubscribe.
                processResult = theSubscriptionManager.ProcessUnsubscription(contactType, contact);
            }
            

            // If result is ok.
            if (processResult.IsSuccessful)
            {
                resultLabel.ForeColor = Color.Green;
            }


            // Set label.
            resultLabel.Text = processResult.ResultMsg;
        }

    }
}
