namespace TravelRouteConsole.Business
{
    public interface ITravelRouteApi
    {
        TResponse GetSync<TResponse>(string requestUri);


        void PostSync<TRequest>(string requestUri, TRequest request);
    }
}
