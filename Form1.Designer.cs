namespace BrenBaga_Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.manageSubscriptionBtn = new System.Windows.Forms.Button();
            this.publishNotificationBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // manageSubscriptionBtn
            // 
            this.manageSubscriptionBtn.AutoSize = true;
            this.manageSubscriptionBtn.Location = new System.Drawing.Point(37, 39);
            this.manageSubscriptionBtn.Name = "manageSubscriptionBtn";
            this.manageSubscriptionBtn.Size = new System.Drawing.Size(129, 25);
            this.manageSubscriptionBtn.TabIndex = 0;
            this.manageSubscriptionBtn.Text = "Manage Subscription";
            this.manageSubscriptionBtn.UseVisualStyleBackColor = true;
            this.manageSubscriptionBtn.Click += new System.EventHandler(this.manageSubscriptionBtn_Click);
            // 
            // publishNotificationBtn
            // 
            this.publishNotificationBtn.AutoSize = true;
            this.publishNotificationBtn.Location = new System.Drawing.Point(200, 39);
            this.publishNotificationBtn.Name = "publishNotificationBtn";
            this.publishNotificationBtn.Size = new System.Drawing.Size(122, 25);
            this.publishNotificationBtn.TabIndex = 1;
            this.publishNotificationBtn.Text = "Publish Notification";
            this.publishNotificationBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.AutoSize = true;
            this.exitBtn.Location = new System.Drawing.Point(359, 39);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 25);
            this.exitBtn.TabIndex = 2;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 102);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.publishNotificationBtn);
            this.Controls.Add(this.manageSubscriptionBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button manageSubscriptionBtn;
        private Button publishNotificationBtn;
        private Button exitBtn;
    }
}