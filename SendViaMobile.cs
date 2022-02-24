using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class SendViaMobile
    {
        public String CellPhone { get; set; }



        public SendViaMobile() { }



        public SendViaMobile(String phone)
        {
            CellPhone = phone;
        }



        private void sendMessage(string msg)
        {
            Console.WriteLine("The message " + "\"" + msg + "\" was texted to " + CellPhone);
        }



        public void Subscribe(Publisher pub)
        {
            pub.publishmsg += sendMessage;
        }



        public void Unsubscribe(Publisher pub)
        {
            pub.publishmsg -= sendMessage;
        }
    }
}
