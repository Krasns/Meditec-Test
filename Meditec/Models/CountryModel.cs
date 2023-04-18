using Newtonsoft.Json;
using System.Collections.Generic;

namespace Meditec.Models
{
    public class CountryModel
    {
        [JsonProperty("error")]
        public bool Error { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Data> Data { get; set; }
    }
       
    public class Data
    {
        [JsonProperty("iso2")]
        public string iso2 { get; set; }

        [JsonProperty("iso3")]
        public string iso3 { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cities")]
        public List<string> Cities { get; set; }

    }
}
