﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Models.Page;
using BlazerSozluk.common.Models.Queries;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Queries.GetEntryComments
{
	public class GetEntryCommentsQuery : BasePagedQuery,IRequest<PagedViewModel<GetEntryCommentsViewModel>>
	{
		public GetEntryCommentsQuery(Guid entryId, Guid? userId, int page, int pageSize) : base(page, pageSize)
		{
			EntryId = entryId;
			UserId = userId;
		}


		public Guid? EntryId { get; set; }	

		public Guid? UserId { get; set; }	

	}
}
