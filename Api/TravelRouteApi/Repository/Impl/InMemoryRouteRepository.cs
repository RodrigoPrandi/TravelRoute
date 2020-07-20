using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using TravelRouteApi.Dto;

namespace TravelRouteApi.Repository.Impl
{
    public class InMemoryRouteRepository : IRouteRepository
    {

        private static List<RouteValue> routeValues = new List<RouteValue>();
        
        public bool Exists(RouteValue routeValue)
        {
            return routeValues.Exists(route => route.From == routeValue.From && route.To == routeValue.To);
        }

        public void Save(RouteValue routeValue)
        {
            if (!Exists(routeValue))
                routeValues.Add(routeValue);
        }

        public List<RouteValue> GetAll()
        {
            return routeValues;
        }
    }
}
