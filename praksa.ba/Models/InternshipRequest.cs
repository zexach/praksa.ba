using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praksa.ba.Models
{
    public class InternshipRequest
    {
        public string postImageUrl { get; set; }
        public string position { get; set; }
        public string company { get; set; }
        public string location { get; set; }
        public string endDate { get; set; }
        public string duration { get; set; }
        public string[] technologies { get; set; }
        public string companyDescription { get; set; }
        public string internshipDescription { get; set; }
        public string applicationLink { get; set; }
        public string user { get; set; }
    }
}
