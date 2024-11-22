using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Api.Application.Features.Queries.GetEntryDetail
{
	public class GetEntryDetailQueryHandler : IRequestHandler<GetEntryDetailQuery, GetEntryDetailedViewModel>
	{
		private readonly IEntryRepository EntryRepository;

		public GetEntryDetailQueryHandler(IEntryRepository entryRepository)
		{
			EntryRepository = entryRepository;
		}

		public async Task<GetEntryDetailedViewModel> Handle(GetEntryDetailQuery request, CancellationToken cancellationToken)
		{
			var query = EntryRepository.AsQueryable();
			query = query.Include(i => i.EntryFavorites)
					   .Include(i => i.CreatedBy)
					   .Include(i => i.EntryVotes);


			var list = query.Select(i => new GetEntryDetailedViewModel()
			{
				Id = i.Id,
				Subject = i.Subject,
				Content = i.Content,
				IsFavorited = request.UserId.HasValue && i.EntryFavorites.Any(j => j.CreatedById == request.UserId),
				FavoritedCount = i.EntryFavorites.Count,
				CreatedDate = i.CreateDate,
				CreatedByUserName = i.CreatedBy.UserName,
				VoteType = request.UserId.HasValue && i.EntryVotes.Any(j => j.CreatedById == request.UserId)
					? i.EntryVotes.FirstOrDefault(j => j.CreatedById == request.UserId).voteType : common.ViewModels.VoteType.None,




			});

			return await list.FirstOrDefaultAsync(cancellationToken: cancellationToken);
		}
	}
}
