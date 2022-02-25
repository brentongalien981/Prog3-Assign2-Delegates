using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class TheSubscriptions : IDisposable
    {
        public HashSet<SendViaType>? EmailSubscriptionSet { get; set; }
        public HashSet<SendViaType>? MobileSubscriptionSet { get; set; }

        public void Dispose()
        {

        }



        public TheSubscriptions(HashSet<SendViaType> emailSubscriptionSet, HashSet<SendViaType> mobileSubscriptionSet)
        {
            EmailSubscriptionSet = emailSubscriptionSet;
            MobileSubscriptionSet = mobileSubscriptionSet;
        }
    }
}
