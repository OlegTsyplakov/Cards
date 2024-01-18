using Cards.Data.Models;
using Cards.Domain;
using Cards.Domain.Russian;
using Cards.Domain.Standart;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace Cards.Data.Repositories
{
    public class InMemoryDBRepository : IDecksRepository
    {
        private readonly ApiContext _apiContext;

        public InMemoryDBRepository()
        {
            _apiContext = new ApiContext();
        }
        public void CreateDeck<T>(string deckName) where T : Enum
        {

            switch (typeof(T))
            {
                case Type t when t == typeof(CardNumberStandart):
                    var deck = new Deck<CardNumberStandart>(deckName);
                    var cards = deck.GetCards.Select(x => new CardModel()
                    {
                        CardType = Convert.ToInt32(x.CardType),
                        Suit=x.Suit,
                    }).ToArray();
                    _apiContext.Decks.Add(new DeckModel()
                    {
                      Name= deckName,
                      Type= t.Name,
                      Cards = cards
                    });
                    _apiContext.SaveChanges();
                    break;
                case Type t when t == typeof(CardNumberRussian):
                    var deck2 = new Deck<CardNumberStandart>(deckName);
                    var cards2 = deck2.GetCards.Select(x => new CardModel()
                    {
                        CardType = Convert.ToInt32(x.CardType),
                        Suit = x.Suit,
                    }).ToArray();
                    _apiContext.Decks.Add(new DeckModel() { 
                    Name = deckName,
                    Type = t.Name,
                    Cards = cards2
                    });
                    _apiContext.SaveChanges();
                    break;
                default:
                    Console.WriteLine("not valid Enum");
                    break;
            }

         
        }

        public IDeck? GetDeck(string deckName)
        {
            var deckModel = _apiContext.Decks.Where(x => x.Name == deckName).FirstOrDefault();
            if (deckModel is not null)
            {
                return Mapper.Mapper.MapDeckModelToIDeck(deckModel);
            }
                    return null;
        }

        public IEnumerable<string> GetDeckNames()
        {
            return _apiContext.Decks.Select(x => x.Name);
        }

        public void RemoveDeck(string deckName)
        {
            var deckModel = _apiContext.Decks.Where(x => x.Name == deckName).FirstOrDefault();
            if (deckModel is not null)
            {
                _apiContext.Decks.Remove(deckModel);
            }
        }

        public void ShuffleDeck(string deckName, ShuffleAlgorithm shuffleAlgorithm)
        {
            var deckModel = _apiContext.Decks.Where(x => x.Name == deckName).FirstOrDefault();
            if (deckModel is not null)
            {

               // Not implemented
            }

        }
    }
}
