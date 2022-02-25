using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BrenBaga_Lab2
{
    internal class SendViaType
    {
        public String Contact { get; set; }


        public SendViaType()
        {

        }



        public SendViaType(String contact)
        {
            Contact = contact;
        }



        public virtual void send(string msg)
        {
            string notification = "The message " + "\"" + msg + "\" was sent to " + Contact;
            NotificationsDisplayManager.DisplayNotification(notification);
        }



        public void Subscribe(Publisher pub)
        {
            pub.publishmsg += send;
        }



        public void Unsubscribe(Publisher pub)
        {
            pub.publishmsg -= send;
        }
    }
}