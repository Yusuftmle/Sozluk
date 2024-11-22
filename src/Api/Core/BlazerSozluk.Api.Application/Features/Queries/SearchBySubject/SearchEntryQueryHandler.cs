using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Models.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Api.Application.Features.Queries.SearchBySubject
{
	public class SearchEntryQueryHandler : IRequestHandler<SearchEntryQuery, List<SearchEntryViewModel>>
	{
		private readonly IEntryRepository EntryRepository;

		public SearchEntryQueryHandler(IEntryRepository entryRepository)
		{
			EntryRepository = entryRepository;
		}

		public async Task<List<SearchEntryViewModel>> Handle(SearchEntryQuery request, CancellationToken cancellationToken)
		{
			var result = EntryRepository
		   .Get(i => EF.Functions.Like(i.Subject, $"{request.SearchText}%"))
	       .Select(i => new SearchEntryViewModel()
	       {
		     Id = i.Id,
		    Subject = i.Subject,
	       });

			return await result.ToListAsync(cancellationToken);

		}
	}
}