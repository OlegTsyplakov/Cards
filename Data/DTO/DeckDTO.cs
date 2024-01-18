namespace Cards.Data.DTO
{
    public class DeckDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Enum DeckType { get; set; }
        public IEnumerable<CardDTO> Cards { get; set; }
    }
}
