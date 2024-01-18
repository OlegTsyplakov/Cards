using Cards.Domain;
using Microsoft.EntityFrameworkCore;


namespace Cards.Data.Models
{
    public class ApiContext : DbContext
    {
 
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DecksDb");
        }
        public  DbSet<DeckModel> Decks { get; set; }
 
        public DbSet<CardModel> Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cards = modelBuilder.Entity<CardModel>();
            cards.ToTable("Cards");
            cards.Property(x => x.Suit).IsRequired();
            cards.Property(x => x.CardType).IsRequired();
            cards.HasKey(x => x.CardId);
            cards.HasOne(x => x.Deck).WithMany(x => x.Cards).HasForeignKey("DeckModelId").IsRequired();

            var decks = modelBuilder.Entity<DeckModel>();
            decks.HasKey(x => x.DeckId);
            decks.Property(x => x.Name).IsRequired();
            decks.Property(x => x.Type).IsRequired();

       
            // Seed data for testing

            modelBuilder.Entity<DeckModel>().HasData(
                
                new DeckModel()
                {
                    DeckId = 1,
                    Name = "seed name",
                    Type="seed type",
                }
                );
            modelBuilder.Entity<CardModel>().HasData(
                
                new CardModel()
                {
                    CardId = 1,
                    Suit=Suit.Diamond,
                    CardType=10,
                    DeckModelId=1,
                }
                );

        }

    }
}
