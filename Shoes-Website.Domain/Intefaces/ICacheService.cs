namespace Shoes_Website.Domain.Intefaces
{
    public interface ICacheService
    {
        void SetCache<T>(string key, T cachedObject, int slidingOption);

        T GetFromCache<T>(string key);

        void RemoveCache(string key);

        void RemoveManyCache(params string[] keys);
    }
}
