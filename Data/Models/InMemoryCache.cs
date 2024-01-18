using Microsoft.Extensions.Caching.Memory;



namespace Cards.Data.Models
{
    public class InMemoryCache
    {
        public MemoryCache Cache { get; } = new MemoryCache(
        new MemoryCacheOptions
        {

        });

    }
}
