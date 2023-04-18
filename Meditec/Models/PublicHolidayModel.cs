using Newtonsoft.Json;
using System.Collections.Generic;

namespace Meditec.Models
{
    public class PublicHolidayModel
    {

        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("localName")]
        public string LocalName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("fixed")]
        public bool Fixed { get; set; }
        [JsonProperty("global")]
        public bool Global { get; set; }
        [JsonProperty("counties")]
        public List<string> Counties { get; set; }
        [JsonProperty("launchYear")]
        public int? LaunchYear { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
