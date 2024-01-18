
namespace Cards.Domain
{
   public  class Card<T> where T : Enum
    {
        public Suit Suit { get; set; }
        public required T CardType { get; set; }

    }

}
