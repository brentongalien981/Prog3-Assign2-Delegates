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
            //
        }



        public TheSubscriptions(HashSet<SendViaType> emailSubscriptionSet, HashSet<SendViaType> mobileSubscriptionSet)
        {
            EmailSubscriptionSet = emailSubscriptionSet;
            MobileSubscriptionSet = mobileSubscriptionSet;
        }



        public bool DoesContactExistInSet(string subscriptionType, string contact)
        {
            var subscriptionSet = EmailSubscriptionSet;

            if (subscriptionType.Equals("mobile"))
            {
                subscriptionSet = MobileSubscriptionSet;
            }


            foreach (var subscription in subscriptionSet)
            {
                if (subscription.Contact.Equals(contact))
                {
                    return true;
                }
            }

            return false;
        }



        public SendViaType GetSubscription(string contact, string subscriptionType)
        {
            HashSet<SendViaType> subscriptionSet = EmailSubscriptionSet;

            if (subscriptionType.Equals("mobile"))
            {
                subscriptionSet = MobileSubscriptionSet;
            }


            foreach (var subscription in subscriptionSet)
            {
                if (subscription.Contact.Equals(contact))
                {
                    return subscription;
                }
            }

            return null;

        }
    }
}
