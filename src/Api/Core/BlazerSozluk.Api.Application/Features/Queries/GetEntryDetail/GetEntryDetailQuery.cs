using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Models.Queries;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Queries.GetEntryDetail
{
	public class GetEntryDetailQuery:IRequest<GetEntryDetailedViewModel>
	{
		public Guid? EntryId { get; set; }

		public Guid? UserId { get; set; }
		public GetEntryDetailQuery(Guid? entryId, Guid? userId)
		{
			EntryId = entryId;
			UserId = userId;
		}

		
	}
}
