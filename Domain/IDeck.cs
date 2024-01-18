

namespace Cards.Domain
{
    public interface IDeck
    {
        Type DeckType { get; }
        string DeckName { get; }
        void ShuffleSimple();
        void ShuffleFisherYates();
    }
}
