namespace BlazerSozluk.Projections.VoteService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    
                })
                .Build();

            host.Run();
        }
    }
}