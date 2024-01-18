using Cards.Data.Repositories;


namespace Cards.Domain
{
    public class DecksRepository
    {
        private readonly ShuffleAlgorithm _shuffleAlgorithm;
        private readonly IDecksRepository _decksRepository;  

        public DecksRepository(ShuffleAlgorithm shuffleAlgorithm, IDecksRepository decksRepository)
        {
            _decksRepository = decksRepository;
            _shuffleAlgorithm = shuffleAlgorithm;
        }

        public void CreateDeck<T>(string deckName) where T : Enum
        {
            _decksRepository.CreateDeck<T>(deckName);
        }

        public IDeck? GetDeck(string deckName)
        {
          return  _decksRepository.GetDeck(deckName);
        }

        public IEnumerable<string> GetDeckNames()
        {
            return _decksRepository.GetDeckNames();
        }

        public void RemoveDeck(string deckName)
        {
            _decksRepository.RemoveDeck(deckName);
        }

        public void ShuffleDeck(string deckName)
        {
          _decksRepository.ShuffleDeck(deckName, _shuffleAlgorithm);
        }
    }
}
