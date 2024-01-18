

using System.Text;

namespace Cards.Domain
{
    public class Deck<T>(string deckName):IDeck where T :Enum ,new()
    {
        IList<Card<T>> Cards { get; set; } = FillDeck();
        public string DeckName { get; init; } = deckName;
        public IEnumerable<Card<T>> GetCards => Cards;
        public Type DeckType => typeof(T);

        private static Card<T>[] FillDeck()
        {
            return Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, Enum.GetValues(typeof(T)).Length)
                                    .Select(c => new Card<T>()
                                    {
                                        Suit = (Suit)s,
                                        CardType = (T)Enum.Parse(typeof(T), c.ToString(), true)
                                    }
                                                )
                            ).ToArray();
        }

        public void ShuffleSimple()
        {
            var rand = new Random();
            Cards = Cards.OrderBy(_ => rand.Next()).ToArray();
        }

        public void ShuffleFisherYates()
        {
            var rand = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                var k = rand.Next(i + 1);
                (Cards[i], Cards[k]) = (Cards[k], Cards[i]);
            }
        }
        public override string ToString()
        {
            StringBuilder result = new();
            foreach (var card in Cards)
            {
                result.Append(card.Suit+" "+card.CardType+"\n");
            }
            return result.ToString();
        }
    }


}
