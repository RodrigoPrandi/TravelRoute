using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelRouteApi.Dto
{
    public class RouteValue : Route
    {
        public int Value { get; set; }

        [JsonConstructor]
        public RouteValue(string from, string to, int value) : base(from, to)
        {
            Value = value;
        }
    }
}
