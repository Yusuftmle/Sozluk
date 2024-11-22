using BlazerSozluk.common;
using BlazerSozluk.common.Events.Entry;
using BlazerSozluk.common.Events.EntryComment;
using BlazerSozluk.common.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BlazerSozluk.Projections.FavoriteService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
		private readonly IConfiguration configuration;

		public Worker(ILogger<Worker> logger,IConfiguration configuration)
        {
            _logger = logger;
			this.configuration = configuration;
		}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conStr = configuration.GetConnectionString("SqlServer");

			var favService = new Services.FavoriteService(conStr);
               QueueFactory.CreateBasicConsumer()
                 .EnsureExchange(SozlukConstants.FavExchangeName)
                 .EnsureQueue(SozlukConstants.CreateEntryFavQueueName, SozlukConstants.FavExchangeName)
                 .Receive<CreateEntryFavEvent>(fav =>
                 {
                     favService.CreateEntryFav(fav).GetAwaiter().GetResult();
                     _logger.LogInformation($"Received EntryId {fav.EntryId}");
                 })
                 .StartConsuming(SozlukConstants.CreateEntryFavQueueName);

			QueueFactory.CreateBasicConsumer()
		   .EnsureExchange(SozlukConstants.FavExchangeName)
		   .EnsureQueue(SozlukConstants.DeleteEntryFavQueueName, SozlukConstants.FavExchangeName)
		   .Receive<DeleteEntryFavEvent>(fav =>
		   {
			   favService.DeleteEntryFav(fav).GetAwaiter().GetResult();
			   _logger.LogInformation($"Deleted Received EntryId {fav.EntryId}");
		   })
		   .StartConsuming(SozlukConstants.DeleteEntryFavQueueName);



			QueueFactory.CreateBasicConsumer()
				.EnsureExchange(SozlukConstants.FavExchangeName)
				.EnsureQueue(SozlukConstants.CreateEntryCommentFavQueueName, SozlukConstants.FavExchangeName)
				.Receive<CreateEntryCommentFavEvent>(fav =>
				{
					favService.CreateEntryCommentFav(fav).GetAwaiter().GetResult();
					_logger.LogInformation($"Create EntryComment Received EntryCommentId {fav.EntryCommentId}");
				})
				.StartConsuming(SozlukConstants.CreateEntryCommentFavQueueName);


			QueueFactory.CreateBasicConsumer()
				.EnsureExchange(SozlukConstants.FavExchangeName)
				.EnsureQueue(SozlukConstants.DeleteEntryCommentFavQueueName, SozlukConstants.FavExchangeName)
				.Receive<DeleteEntryCommentFavEvent>(fav =>
				{
					favService.DeleteEntryCommentFav(fav).GetAwaiter().GetResult();
					_logger.LogInformation($"Deleted Received EntryCommentId {fav.EntryCommentId}");
				})
				.StartConsuming(SozlukConstants.DeleteEntryCommentFavQueueName);
		}
	
    }
}