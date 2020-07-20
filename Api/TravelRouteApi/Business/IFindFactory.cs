namespace TravelRouteApi.Business
{
    public interface IFindFactory
    {
        IBestRouteFinder GetFinder(FindBestBy findBestBy);
    }
}
