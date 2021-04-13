using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    class User
    {
        public string Username { get; set; }
        public List<MessageBox> Messages { get; set; }
    }
}
