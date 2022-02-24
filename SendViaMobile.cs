using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrenBaga_Lab2
{
    internal class SendViaMobile : SendViaType
    {
        public SendViaMobile(String contact) : base(contact)
        {

        }

        public override void send(string msg)
        {
            Console.WriteLine("The message " + "\"" + msg + "\" was texted to " + Contact);
        }
    }
}
