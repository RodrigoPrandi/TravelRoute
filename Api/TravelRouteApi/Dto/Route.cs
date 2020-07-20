using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRouteApi.Dto
{
    public class Route
    {
        public string From { get; set; }
        public string To { get; set; }

        [JsonConstructor]
        public Route(string from, string to)
        {
            From = from;
            To = to;
        }
    }
}
