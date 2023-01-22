using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praksa.ba.Models
{
    public class Internship
    {
        [JsonProperty("_id")]
        public string id { get; set; }

        [JsonProperty("postImageUrl")]
        public string postImageUrl { get; set; }

        [JsonProperty("position")]
        public string position { get; set; }

        [JsonProperty("company")]
        public string company { get; set; }

        [JsonProperty("location")]
        public string location { get; set; }

        [JsonProperty("endDate")]
        public string endDate { get; set; }

        [JsonProperty("duration")]
        public string duration { get; set; }

        [JsonProperty("technologies")]
        public string[] technologies { get; set; }

        [JsonProperty("companyDescription")]
        public string companyDescription { get; set; }

        [JsonProperty("internshipDescription")]
        public string internshipDescription { get; set; }

        [JsonProperty("applicationLink")]
        public string applicationLink { get; set; }

        [JsonProperty("user")]
        public string user { get; set; }
    }
}
