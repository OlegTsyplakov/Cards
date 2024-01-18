
using Cards.Data.Repositories;
using Cards.Domain;
using Cards.Domain.Russian;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
       

  // Начало вызов

            var dr = new DecksRepository(ShuffleAlgorithm.FisherYates, new SimpleRepository());
            dr.CreateDeck<CardNumberRussian>("a21211");
           

            dr.ShuffleDeck("a21211");

            foreach(var s in dr.GetDeckNames())
            {
                Console.WriteLine(s);
            }
            var id = dr.GetDeck("a21211");
            Console.WriteLine(id?.ToString());

// Конец вызов



            host.Run();

            static IHostBuilder CreateHostBuilder(string[] strings)
            {
                return Host.CreateDefaultBuilder()
                    .ConfigureServices((_, services) =>
                    {
                        services.AddSingleton<IDecksRepository, SimpleRepository>();

                        //services.AddSingleton<InMemoryCache>();
                        //services.AddMemoryCache();
                    });
            }


        }


      


    }
}
