namespace BlazerSozluk.Projections.FavoriteService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<Services.FavoriteService>();
                })
                .Build();

            host.Run();
        }
    }
}