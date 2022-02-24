using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class SendViaEmail
    {
        public String EmailAddr { get; set; }



        public SendViaEmail() { }


        public SendViaEmail(String emailAddr)
        {
            EmailAddr = emailAddr;
        }



        public void sendEmail(string msg)
        {
            Console.WriteLine("The message" + "\"" + msg + "\" was sent to " + EmailAddr);
        }



        public void Subscribe(Publisher pub)
        {
            pub.publishmsg += sendEmail;
        }



        public void Unsubscribe(Publisher pub)
        {
            pub.publishmsg -= sendEmail;
        }
    }
}
