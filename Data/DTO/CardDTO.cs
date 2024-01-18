using Cards.Domain;

namespace Cards.Data.DTO
{
    public class CardDTO
    {

        public int Id { get; set; }
        public Suit Suit { get; set; }
        public Enum CardType { get; set; }
    }
}
