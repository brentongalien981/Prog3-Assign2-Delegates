namespace BrenBaga_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}