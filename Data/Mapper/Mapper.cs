

using Cards.Data.DTO;
using Cards.Data.Models;
using Cards.Domain;


namespace Cards.Data.Mapper
{
    public static class Mapper
    {

        public static DeckDTO MapDeckModelToDeckDTO(DeckModel deckModel)
        {

            return new DeckDTO()
            {
                Id = deckModel.DeckId,
                Name = deckModel.Name,
                DeckType = (Enum)Convert.ChangeType(deckModel.Type, typeof(Enum)),
                Cards = deckModel.Cards.Select(x => MapCardModelToCardDTO(x))
            };

        }

        public static CardDTO MapCardModelToCardDTO(CardModel cardModel)
        {
            return new CardDTO()
            {
                Id= cardModel.CardId,
                Suit = cardModel.Suit,
                CardType = (Enum)Convert.ChangeType(cardModel.CardType, typeof(Enum))
            };
        }

        public static DeckModel MapDeckDTOToDeckModel(DeckDTO deckDTO)
        {
            return new DeckModel()
            {
                DeckId= deckDTO.Id, 
                Name = deckDTO.Name,
                Type= deckDTO.DeckType.GetType().ToString(),
                Cards= deckDTO.Cards.Select(x=>MapCardDTOToCardModel(x)).ToArray()
            };
        }

        public static CardModel MapCardDTOToCardModel(CardDTO cardDTO)
        {
            return new CardModel() {
                CardId= cardDTO.Id,
                Suit= cardDTO.Suit,
                CardType= Convert.ToInt32(cardDTO.CardType)
            };
        }

        public static IDeck? MapDeckDTOToIDeck(DeckDTO deckDTO)
        {
            var type = deckDTO.DeckType.GetType();
            var iDeck = (IDeck)Activator.CreateInstance(typeof(Deck<>).MakeGenericType(type));
            return iDeck;
        }
        public static IDeck? MapDeckModelToIDeck(DeckModel deckModel)
        {
            var type = deckModel.Type.GetType();
            var iDeck = (IDeck)Activator.CreateInstance(typeof(Deck<>).MakeGenericType(type));
            return iDeck;
        }
    }
}
