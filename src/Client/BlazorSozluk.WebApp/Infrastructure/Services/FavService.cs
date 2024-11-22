using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
    public class FavService : IFavService
	{
		private readonly HttpClient Client;

		public FavService(HttpClient client)
		{
			Client = client;
		}

		public async Task CreateEntryFav(Guid? entryId)
		{
			await Client.PostAsync($"/api/favorite/Entry/{entryId}", null);
		}

		public async Task CreateEntryCommentFav(Guid? entryCommentId)
		{
			await Client.PostAsync($"/api/favorite/EntryComment/{entryCommentId}", null);
		}

		public async Task DeleteEntryFav(Guid? entryId)
		{
			await Client.PostAsync($"/api/favorite/DeleteEntryFav/{entryId}", null);
		}

		public async Task DeleteEntryCommentFav(Guid? entryCommentId)
		{
			await Client.PostAsync($"/api/favorite/DeleteEntryCommentFav/{entryCommentId}", null);
		}

	}
}
