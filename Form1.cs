namespace BrenBaga_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Initialize this MainForm to observe for the number of subscriptions,
            // so that you can enable or disable the publish-button.
            TheSubscriptionObserver theObserver = new TheSubscriptionObserver(this);
            TheSubscriptionManager.getSingletonInstance().Subscribe(theObserver);
        }



        private void manageSubscriptionBtn_Click(object sender, EventArgs e)
        {
            ManageSubscriptionForm frm = new ManageSubscriptionForm();
            frm.ShowDialog();
        }



        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        internal void SetMainStatusLabel(string newLabel)
        {
            this.mainStatusLabel.Text = newLabel;
        }



        internal void SetPublishBtn(bool shouldEnablePublishBtn)
        {
            this.publishNotificationBtn.Enabled = shouldEnablePublishBtn;
        }

        private void publishNotificationBtn_Click(object sender, EventArgs e)
        {
            NotificationPublisher form = new NotificationPublisher();
            form.ShowDialog();
        }
    }
}