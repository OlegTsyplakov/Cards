using Cards.Domain;

namespace Cards.Data.Repositories
{
    public interface IDecksRepository
    {
        void CreateDeck<T>(string deckName) where T : Enum;
        void ShuffleDeck(string deckName, ShuffleAlgorithm shuffleAlgorithm);
        void RemoveDeck(string deckName);
        IDeck? GetDeck(string deckName);
        IEnumerable<string> GetDeckNames();

    }
}
