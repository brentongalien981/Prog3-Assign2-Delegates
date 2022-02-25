using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class TheSubscriptionObserver : IObserver<TheSubscriptions>
    {
        private Form1 theMainForm;

        public TheSubscriptionObserver(Form1 form1)
        {
            this.theMainForm = form1;
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(TheSubscriptions theSubscriptions)
        {
            bool shouldEnablePublishBtn = false;

            if (theSubscriptions.EmailSubscriptionSet.Count > 0 || theSubscriptions.MobileSubscriptionSet.Count > 0)
            {
                shouldEnablePublishBtn = true;
            }

            theMainForm.SetPublishBtn(shouldEnablePublishBtn);
        }
    }
}
