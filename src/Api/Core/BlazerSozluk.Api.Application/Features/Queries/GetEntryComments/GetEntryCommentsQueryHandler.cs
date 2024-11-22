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

namespace BlazerSozluk.Api.Application.Features.Queries.GetEntryComments
{
	public class GetEntryCommentsQueryHandler : IRequestHandler<GetEntryCommentsQuery, PagedViewModel<GetEntryCommentsViewModel>>
	{
		private readonly IEntryCommentRepository EntryCommentRepository;

		public GetEntryCommentsQueryHandler(IEntryCommentRepository entryCommentRepository)
		{
			EntryCommentRepository = entryCommentRepository;
		}

		public async Task<PagedViewModel<GetEntryCommentsViewModel>> Handle(GetEntryCommentsQuery request, CancellationToken cancellationToken)
		{
			var query = EntryCommentRepository.AsQueryable();

			query = query.Include(i => i.EntryCommentFavorites)
					   .Include(i => i.CreatedBy)
					   .Include(i => i.EntryCommentVotes)
					   .Where(i => i.EntryId == request.EntryId);


			var list = query.Select(i => new GetEntryCommentsViewModel()
			{
				Id = i.Id,
				Content = i.Content,
				IsFavorited = request.UserId.HasValue && i.EntryCommentFavorites.Any(j => j.CreatedById == request.UserId),
				FavoritedCount = i.EntryCommentFavorites.Count,
				CreatedDate = i.CreateDate,
				CreatedByUsername = i.CreatedBy.UserName,
				VoteType = request.UserId.HasValue && i.EntryCommentVotes.Any(j => j.CreateById == request.UserId)
					? i.EntryCommentVotes.FirstOrDefault(j => j.CreateById == request.UserId).voteType : common.ViewModels.VoteType.None,




			});

			var entries = await list.GetPaged(request.Page, request.pageSize);
			return entries;
		}
	}
}
