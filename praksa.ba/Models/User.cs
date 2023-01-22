using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praksa.ba.Models
{
    public class User
    {
        public string _id { get; set; }
        public string fullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string typeOfUser { get; set; }
    }
}
