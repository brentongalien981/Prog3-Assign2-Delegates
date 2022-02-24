using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class TheSubscriptionManager : IObservable<HashSet<SendViaType>>
    {
        private static HashSet<SendViaType> emailSubscriptionSet = new HashSet<SendViaType>();
        private static HashSet<SendViaType> mobileSubscriptionSet = new HashSet<SendViaType>();
        private static Publisher publisher = new Publisher();



        public IDisposable Subscribe(IObserver<HashSet<SendViaType>> observer)
        {
            throw new NotImplementedException();
        }



        private static bool doesContactExistInSet(string subscriptionType, string contact)
        {
            var subscriptionSet = emailSubscriptionSet;

            if (subscriptionType.Equals("mobile"))
            {
                subscriptionSet = mobileSubscriptionSet;
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



        public static SubscriptionResult ProcessSubscription(string subscriptionType, string contact)
        {
            bool isWholeProcessOk = false;
            string resultMsg = "";

            // Validate contact.
            bool isContactValid = MyValidator.validate(subscriptionType, contact);


            // If contact is invalid, return..
            if (!isContactValid)
            {
                resultMsg = $"Invalid {subscriptionType}.";

                return new SubscriptionResult(isWholeProcessOk, resultMsg);
            }


            // If contact already exists, return.
            if (doesContactExistInSet(subscriptionType, contact))
            {
                resultMsg = $"Oops, {contact} already exists.";
            }
            else
            {                
                // Add to specific subscriptionSet and subscribe to publisher.
                if (subscriptionType.Equals("email"))
                {
                    // For email.                    
                    var subscription = new SendViaEmail(contact);
                    emailSubscriptionSet.Add(subscription);
                    subscription.Subscribe(publisher);
                }
                else
                {
                    // For mobile.                    
                    var subscription = new SendViaMobile(contact);
                    mobileSubscriptionSet.Add(subscription);
                    subscription.Subscribe(publisher);

                }

                //
                isWholeProcessOk = true;
                resultMsg = $"Succesfully subscribed {contact}!";

            }

            // Return.
            return new SubscriptionResult(isWholeProcessOk, resultMsg);
        }
    }
}
