using Cards.Domain;




namespace Cards.Data.Models
{


    public class CardModel
    {

        public int CardId { get; set; }

        public Suit Suit { get; set; }

        public  int CardType { get; set; }

        public int DeckModelId { get; set; }
        public DeckModel Deck { get; set; } = null!;
    }
}
