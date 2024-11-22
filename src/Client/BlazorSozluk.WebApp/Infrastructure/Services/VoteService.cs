using BlazerSozluk.common.ViewModels;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class VoteService : IVoteService
	{
		private readonly HttpClient HttpClient;

		public VoteService(HttpClient httpClient)
		{
			HttpClient = httpClient;
		}


		public async Task DeleteEntryVote(Guid entryId)
		{
			var response = await HttpClient.PostAsync($"/api/Vote/DeleteEntryVote/{entryId}", null);
			if (!response.IsSuccessStatusCode)
				throw new Exception("DeleteEntryVote error");
		}

		public async Task DeleteEntryCommentVote(Guid entryCommentId)
		{
			var response = await HttpClient.PostAsync($"/api/Vote/DeleteEntryCommentVote/{entryCommentId}", null);
			if (!response.IsSuccessStatusCode)
				throw new Exception("DeleteEntryCommentVote error");
		}

		public async Task CreateEntryUpVote(Guid entryId)
		{
			await CreateEntryVote(entryId, VoteType.UpVote);
		}
		public async Task CreateEntryDownVote(Guid entryId)
		{
			await CreateEntryVote(entryId, VoteType.DownVote);
		}

		public async Task CreateEntryCommentUpVote(Guid entryCommentId)
		{
			await CreateEntryCommentVote(entryCommentId, VoteType.UpVote);
		}
		public async Task CreateEntryCommentDownVote(Guid entryCommentId)
		{
			await CreateEntryCommentVote(entryCommentId, VoteType.DownVote);
		}

		public async Task<HttpResponseMessage> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
		{
			var result = await HttpClient.PostAsync($"/api/vote/entry/{entryId}?voteType{voteType}", null);
			if (!result.IsSuccessStatusCode)
				throw new Exception("CreateEntryVote error");
			return result;
		}

		public async Task<HttpResponseMessage> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
		{
			var result = await HttpClient.PostAsync($"/api/vote/entryComment/{entryCommentId}?voteType{voteType}", null);
			if (!result.IsSuccessStatusCode)
				throw new Exception("CreateEntryCommentVote error");
			return result;
		}
	}
}
