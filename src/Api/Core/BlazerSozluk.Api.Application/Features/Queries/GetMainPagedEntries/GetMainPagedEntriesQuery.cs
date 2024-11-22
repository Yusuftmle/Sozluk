using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Queries.GetMainPagedEntries
{
	public class GetMainPagedEntriesQuery:BasePagedQuery,IRequest<PagedViewModel<GetEntryDetailedViewModel>>
	{
		public GetMainPagedEntriesQuery(Guid? userId,int page, int pageSize) : base(page, pageSize)
		{
			UserId=userId;
		}

		public Guid? UserId { get; set; }
	}
}
