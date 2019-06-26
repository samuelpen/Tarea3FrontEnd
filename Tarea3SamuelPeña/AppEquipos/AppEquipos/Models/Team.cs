using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEquipos.Models
{
    public class Team
    {
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Thumbnail")]
        public string Thumbnail { get; set; }

    }





}
