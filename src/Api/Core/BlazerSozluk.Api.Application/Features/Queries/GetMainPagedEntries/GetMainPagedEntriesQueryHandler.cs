using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Extensions;
using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Api.Application.Features.Queries.GetMainPagedEntries
{
	public class GetMainPagedEntriesQueryHandler : IRequestHandler<GetMainPagedEntriesQuery, PagedViewModel<GetEntryDetailedViewModel>>
	{
		private readonly IEntryRepository entryRepository;
		

		public GetMainPagedEntriesQueryHandler(IEntryRepository entryRepository)
		{
			this.entryRepository = entryRepository;
			
		}

        public async Task<PagedViewModel<GetEntryDetailedViewModel>> Handle(GetMainPagedEntriesQuery request, CancellationToken cancellationToken)
        {
           var query=entryRepository.AsQueryable();

			query = query.AsNoTracking()
                         .Include(i => i.EntryFavorites)
						 .Include(i => i.CreatedBy)
						 .Include(i => i.EntryVotes);


			var list =  query.Select(i => new GetEntryDetailedViewModel()
			{
				Id = i.Id,
				Subject = i.Subject,
				Content = i.Content,
				IsFavorited = request.UserId.HasValue && i.EntryFavorites.Any(j => j.CreatedById == request.UserId),
				FavoritedCount = i.EntryFavorites.Count,
				CreatedDate = i.CreateDate,
				CreatedByUserName = i.CreatedBy.UserName,
				VoteType = request.UserId.HasValue && i.EntryVotes.Any(j => j.CreatedById == request.UserId)
						 ? i.EntryVotes.FirstOrDefault(j => j.CreatedById == request.UserId).voteType
						 : common.ViewModels.VoteType.None

			});

            var entries = await list.GetPaged(request.Page, request.pageSize);
            return entries;
        }
    }


		


	
}
