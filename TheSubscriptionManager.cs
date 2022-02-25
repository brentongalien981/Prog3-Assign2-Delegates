using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class TheSubscriptionManager : IObservable<TheSubscriptions>
    {
        private HashSet<SendViaType> emailSubscriptionSet;
        private HashSet<SendViaType> mobileSubscriptionSet;
        private Publisher publisher;
        public TheSubscriptions TheSubscriptions;
        private List<IObserver<TheSubscriptions>> subscribers;

        private static TheSubscriptionManager singletonInstance;



        private TheSubscriptionManager()
        {

        }



        public static TheSubscriptionManager getSingletonInstance()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new TheSubscriptionManager();
                singletonInstance.emailSubscriptionSet = new HashSet<SendViaType>();
                singletonInstance.mobileSubscriptionSet = new HashSet<SendViaType>();
                singletonInstance.TheSubscriptions = new TheSubscriptions(singletonInstance.emailSubscriptionSet, singletonInstance.mobileSubscriptionSet);
                singletonInstance.publisher = new Publisher();
                singletonInstance.subscribers = new List<IObserver<TheSubscriptions>>();
            }

            return singletonInstance;
        }



        public IDisposable Subscribe(IObserver<TheSubscriptions> observer)
        {
            if (!subscribers.Contains(observer))
            {
                subscribers.Add(observer);
            }

            return TheSubscriptions;
        }



        private bool doesContactExistInSet(string subscriptionType, string contact)
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



        public SubscriptionResult ProcessSubscription(string subscriptionType, string contact)
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

                // Successful subscription result.
                isWholeProcessOk = true;
                resultMsg = $"Succesfully subscribed {contact}!";

            }


            //
            notifySubscribers();


            // Return.
            return new SubscriptionResult(isWholeProcessOk, resultMsg);
        }



        private void notifySubscribers()
        {
            foreach (var s in subscribers)
            {
                s.OnNext(TheSubscriptions);
            }
        }
    }
}
