using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TravelRouteConsole.Dto;

namespace TravelRouteConsole.Business.Impl
{
    class CsvRouteReader : IRouteReader
    {
        public List<RouteValue> ReadFile(string file)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException("File not found!", file);

            return File.ReadAllLines(file)
                    .Select(a => a.Split(','))
                    .Select(c => {
                        var from = c[0];
                        var to = c[1];
                        var value = Convert.ToInt32(c[2]);

                        return new RouteValue(from, to, value);
                    })
                    .ToList();
        }
    }
}
