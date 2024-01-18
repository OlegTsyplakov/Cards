

using Cards.Data.Models;
using Cards.Domain;
using Cards.Domain.Russian;
using Cards.Domain.Standart;
using Microsoft.Extensions.Caching.Memory;


namespace Cards.Data.Repositories
{
    public class InMemoryCacheRepository : IDecksRepository
    {
        private readonly InMemoryCache _memoryCache = new();
        private readonly IList<string> DeckNames = [];

        public void CreateDeck<T>(string deckName) where T : Enum
        {

            switch (typeof(T))
            {
                case Type t when t == typeof(CardNumberStandart):
                    _memoryCache.Cache.Set(deckName, new Deck<CardNumberStandart>(deckName), new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    });
                    DeckNames.Add(deckName);
                    break;
                case Type t when t == typeof(CardNumberRussian):
                    _memoryCache.Cache.Set(deckName, new Deck<CardNumberRussian>(deckName), new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
                    });
                    DeckNames.Add(deckName);
                    break;
                default:
                    Console.WriteLine("not valid Enum");
                    break;
            }
        }

        public IDeck? GetDeck(string deckName)
        {

            if (_memoryCache.Cache.TryGetValue(deckName, out IDeck? deck))
            {
                return deck;
            }
            return null;
        }

        public IEnumerable<string> GetDeckNames()
        {
            return DeckNames;
        }

        public void RemoveDeck(string deckName)
        {
            DeckNames.Remove(deckName);
            _memoryCache.Cache.Remove(deckName);
        }

        public void ShuffleDeck(string deckName, ShuffleAlgorithm shuffleAlgorithm)
        {
            if (_memoryCache.Cache.TryGetValue(deckName, out IDeck? deck))
            {
                switch (shuffleAlgorithm)
                {
                    case ShuffleAlgorithm.Simple:
                        deck?.ShuffleSimple();
                        break;
                    case ShuffleAlgorithm.FisherYates:
                        deck?.ShuffleFisherYates();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
