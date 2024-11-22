using BlazerSozluk.common.Events.Entry;
using BlazerSozluk.common.Events.EntryComment;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common;
using Microsoft.Extensions.Configuration;

namespace BlazerSozluk.Projections.VoteService
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
			var connStr = configuration.GetConnectionString("SqlServer");

			var voteService = new VoteServices.VoteService(connStr);

			QueueFactory.CreateBasicConsumer()
				.EnsureExchange(SozlukConstants.VoteExchangeName)
				.EnsureQueue(SozlukConstants.CreateEntryVoteQueueName, SozlukConstants.VoteExchangeName)
				.Receive<CreateEntryVoteEvent>(vote =>
				{
					voteService.CreateEntryVote(vote).GetAwaiter().GetResult();
					_logger.LogInformation("Create Entry Received EntryId: {0}, VoteType: {1}", vote.EntryId, vote.VoteType);
				})
				.StartConsuming(SozlukConstants.CreateEntryVoteQueueName);

			QueueFactory.CreateBasicConsumer()
				.EnsureExchange(SozlukConstants.VoteExchangeName)
				.EnsureQueue(SozlukConstants.DeleteEntryVoteQueueName, SozlukConstants.VoteExchangeName)
				.Receive<DeleteEntryVoteEvent>(vote =>
				{
					voteService.DeleteEntryVote(vote.EntryId, vote.CreatedBy).GetAwaiter().GetResult();
					_logger.LogInformation("Delete Entry Received EntryId: {0}", vote.EntryId);
				})
				.StartConsuming(SozlukConstants.DeleteEntryVoteQueueName);


			QueueFactory.CreateBasicConsumer()
					.EnsureExchange(SozlukConstants.VoteExchangeName)
					.EnsureQueue(SozlukConstants.CreateEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
					.Receive<CreateEntryCommentVoteEvent>(vote =>
					{
						voteService.CreateEntryCommentVote(vote).GetAwaiter().GetResult();
						_logger.LogInformation("Create Entry Comment Received EntryCommentId: {0}, VoteType: {1}", vote.EntryCommentId, vote.voteType);
					})
					.StartConsuming(SozlukConstants.CreateEntryCommentVoteQueueName);

			QueueFactory.CreateBasicConsumer()
					.EnsureExchange(SozlukConstants.VoteExchangeName)
					.EnsureQueue(SozlukConstants.DeleteEntryCommentVoteQueueName, SozlukConstants.VoteExchangeName)
					.Receive<DeleteEntryCommentVoteEvent>(vote =>
					{
						voteService.DeleteEntryCommentVote(vote.EntryCommentId, vote.CreatedBy).GetAwaiter().GetResult();
						_logger.LogInformation("Delete Entry Comment Received EntryCommentId: {0}", vote.EntryCommentId);
					})
					.StartConsuming(SozlukConstants.DeleteEntryCommentVoteQueueName);
		}
	
    }
}