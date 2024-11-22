using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Extensions;
using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Api.Application.Features.Queries.GetUserEntries
{
	public class GetUserEntriesQueryHandler : IRequestHandler<GetUserEntriesQuery, PagedViewModel<GetUserEntriesDetailViewModel>>
	{
		private readonly IEntryRepository EntryRepository;

		public GetUserEntriesQueryHandler(IEntryRepository entryRepository)
		{
			EntryRepository = entryRepository;
		}

		public async Task<PagedViewModel<GetUserEntriesDetailViewModel>> Handle(GetUserEntriesQuery request, CancellationToken cancellationToken)
		{
			var query = EntryRepository.AsQueryable();

			if (request.UserId != null && request.UserId.HasValue && request.UserId != Guid.Empty)
			{
				query = query.Where(i => i.CreatedById == request.UserId);
			}
			else if (!string.IsNullOrEmpty(request.UserName))
			{
				query = query.Where(i => i.CreatedBy.UserName == request.UserName);
			}
			else return null;

			query = query.Include(i => i.EntryFavorites)
						 .Include(i => i.CreatedBy);

			var list = query.Select(i => new GetUserEntriesDetailViewModel()
			{
				Id = i.Id,
				Subject = i.Subject,
				Content = i.Content,
				IsFavorited = false,
				FavoritedCount = i.EntryFavorites.Count,
				CreatedDate = i.CreateDate,
				CreatedByUserName = i.CreatedBy.UserName
			});

			var entries = await list.GetPaged(request.Page, request.pageSize);

			return new PagedViewModel<GetUserEntriesDetailViewModel>(entries.Results, entries.PageInfo);

		}
	}
}
