using Cards.Domain;
using Cards.Domain.Russian;
using Cards.Domain.Standart;


namespace Cards.Data.Repositories
{
    public class SimpleRepository : IDecksRepository
    {
        public Dictionary<string, IDeck> _decksDictionary = new();
        public void CreateDeck<T>(string deckName) where T : Enum
        {
            switch (typeof(T))
            {
                case Type t when t == typeof(CardNumberStandart):
                    _ = _decksDictionary.TryAdd(deckName, new Deck<CardNumberStandart>(deckName));
                    break;
                case Type t when t == typeof(CardNumberRussian):
                    _ = _decksDictionary.TryAdd(deckName, new Deck<CardNumberRussian>(deckName));
                    break;
                default:
                    Console.WriteLine("not valid Enum");
                    break;
            }
        }

        public IDeck? GetDeck(string deckName)
        {
            if (_decksDictionary.TryGetValue(deckName, out var deck))
            {
                return deck;
            }
            return null;
        }

        public IEnumerable<string> GetDeckNames()
        {
            return _decksDictionary.Keys;
        }

        public void RemoveDeck(string deckName)
        {
            _ = _decksDictionary.Remove(deckName);
        }

        public void ShuffleDeck(string deckName, ShuffleAlgorithm shuffleAlgorithm)
        {
            if (_decksDictionary.TryGetValue(deckName, out var deck))
            {
                switch (shuffleAlgorithm)
                {
                    case ShuffleAlgorithm.Simple:
                        deck.ShuffleSimple();
                        break;
                    case ShuffleAlgorithm.FisherYates:
                        deck.ShuffleFisherYates();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
