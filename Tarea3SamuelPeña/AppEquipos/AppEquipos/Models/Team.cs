using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEquipos.Models
{
    public class Team
    {
        [JsonProperty(PropertyName = "tame")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "embed")]
        public string Embed { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

    }





}
