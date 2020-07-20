using System;

namespace TravelRouteApi.Business.Impl
{
    public class FindFactory : IFindFactory
    {
        private readonly ILowestPriceFinder lowestPriceFinder;

        public FindFactory(ILowestPriceFinder lowestPriceFinder)
        {
            this.lowestPriceFinder = lowestPriceFinder;
        }

        public IBestRouteFinder GetFinder(FindBestBy findBestBy)
        {
            return findBestBy switch
            {
                FindBestBy.VALUE => lowestPriceFinder,
                _ => throw new NotImplementedException("Other searches not implemented!"),
            };
        }
    }
}
