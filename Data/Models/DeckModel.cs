



namespace Cards.Data.Models
{

    public class DeckModel
    {

        public int DeckId { get; set; }

        public string Name { get; set; }

        public  string Type { get; set; }

        public virtual ICollection<CardModel> Cards { get; set; }

    }
}
