using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Models.RequestModels;

namespace BlazorSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IEntryService
    {
        Task<Guid> CreateEntry(CreateEntryCommand command);
        Task<Guid> CreateEntryComment(CreateEntryCommentCommand command);
        Task<List<GetEntriesViewModel>> GetEntries();
        Task<GetEntryDetailedViewModel> GetEntryDetail(Guid entryId);
		Task<PagedViewModel<GetEntryCommentsViewModel>> GetEntryComments(Guid entryId, int page, int pageSize);
		Task<PagedViewModel<GetEntryDetailedViewModel>> GetMainPageEntries(int page, int pageSize);
        Task<PagedViewModel<GetEntryDetailedViewModel>> GetProfilePageEntries(int page, int pageSize, string userName = null);
        Task<List<SearchEntryViewModel>> SearchBySubject(string searchText);
    }
}