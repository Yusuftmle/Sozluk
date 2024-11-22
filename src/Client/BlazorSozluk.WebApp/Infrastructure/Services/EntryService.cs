using System.Net.Http.Json;
using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Models.RequestModels;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;

namespace BlazorSozluk.WebApp.Infrastructure.Services
{
	public class EntryService : IEntryService
	{
		private readonly HttpClient Client;

		public EntryService(HttpClient client)
		{
			Client = client;
		}

		public async Task<List<GetEntriesViewModel>> GetEntries()
		{
			var result = await Client.GetFromJsonAsync<List<GetEntriesViewModel>>("/api/entry?todaysEntry=false&count=30");
			return result;
		}

		public async Task<GetEntryDetailedViewModel>GetEntryDetail(Guid entryId)
		{
			var result = await Client.GetFromJsonAsync<GetEntryDetailedViewModel>($"/api/entry/{entryId}");
			return result;
		}

		public async Task<PagedViewModel<GetEntryDetailedViewModel>> GetMainPageEntries(int page, int pageSize)
		{
			var result = await Client.GetFromJsonAsync<PagedViewModel<GetEntryDetailedViewModel>>($"/api/entry/mainpageentries?page={page}&pageSize={pageSize}");
			return result;
		}
        public async Task<PagedViewModel<GetEntryDetailedViewModel>> GetProfilePageEntries(int page, int pageSize, string userName)
        {
            var result = await Client.GetFromJsonAsync<PagedViewModel<GetEntryDetailedViewModel>>($"/api/entry/UserEntries?userName={userName}&page={page}&pageSize={pageSize}");

            return result;
        }



        public async Task<Guid> CreateEntry(CreateEntryCommand command)
		{
			var res = await Client.PostAsJsonAsync("/api/Entry/CreateEntry", command);
			if (!res.IsSuccessStatusCode)
				return Guid.Empty;

			var guidStr = await res.Content.ReadAsStringAsync();
			return new Guid(guidStr.Trim('"'));
		}
		public async Task<PagedViewModel<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize)
		{
			var result = await Client.GetFromJsonAsync<PagedViewModel<GetEntryCommentsViewModel>>($"/api/entry/comments/{entryId}?page={page}&pageSize={pageSize}");

			return result;
		}

        public async Task<Guid> CreateEntryComment(CreateEntryCommentCommand command)
        {
            var res = await Client.PostAsJsonAsync("/api/Entry/CreateEntryComment", command);

            if (!res.IsSuccessStatusCode)
                return Guid.Empty;

            var guidStr = await res.Content.ReadAsStringAsync();

            return new Guid(guidStr.Trim('"'));
        }


        public async Task<List<SearchEntryViewModel>> SearchBySubject(string searchText)
		{
			var result = await Client.GetFromJsonAsync<List<SearchEntryViewModel>>($"/api/entry/Search?searchText={searchText}");
			return result;
		}

		
	}
}
