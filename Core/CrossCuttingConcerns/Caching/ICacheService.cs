namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        T? Get<T>(string key);
        void Set<T>(string key, T data, TimeSpan? duration = null);
        void Remove(string key);
        bool IsExists(string key);
    }
}
