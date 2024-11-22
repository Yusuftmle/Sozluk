using BlazerSozluk.Api.Application.Features.Queries.GetEntries;
using BlazerSozluk.Api.Application.Features.Queries.GetEntryComments;
using BlazerSozluk.Api.Application.Features.Queries.GetEntryDetail;
using BlazerSozluk.Api.Application.Features.Queries.GetMainPagedEntries;
using BlazerSozluk.Api.Application.Features.Queries.GetUserEntries;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazerSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class EntryController : BaseController
    {

        private readonly IMediator mediator;

        public EntryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await mediator.Send(new GetEntryDetailQuery(id, UserId));
			return Ok(result);
		 }

		[HttpGet]
		[Route("Comments/{id}")]
		public async Task<IActionResult> GetEntryComments(Guid id, int page, int pageSize)
		{
			var result = await mediator.Send(new GetEntryCommentsQuery(id, UserId, page, pageSize));
			return Ok(result);
		}

        [HttpGet]
        [Route("UserEntries")]
        
        public async Task<IActionResult> GetUserEntries(string userName, Guid userId, int page, int pageSize)
        {
            if (userId == Guid.Empty && string.IsNullOrEmpty(userName))
                userId = UserId.Value;

            var result = await mediator.Send(new GetUserEntriesQuery(userId, userName, page, pageSize));

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQueries queries)
        {
            var entries = await mediator.Send(queries);
            return Ok(entries);
        }

		[HttpGet]
        [Route("MainPageEntries")]
		public async Task<IActionResult> GetMainPageEntries(int page,int pageSize)
		{
			var entries = await mediator.Send(new GetMainPagedEntriesQuery(UserId, page, pageSize));

			return Ok(entries);

		}

		[HttpPost]
        [Route("CreateEntry")]
		[Authorize]
		public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateEntryComment")]
        [Authorize]
        public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommand command)
        {
            if (!command.CreatedById.HasValue)
                command.CreatedById = UserId;

            var result = await mediator.Send(command);

            return Ok(result);
        }


        [HttpGet]
        [Route("Search")]

        public async Task<IActionResult> Search([FromQuery] SearchEntryQuery searchEntryQuery)
        {
            var result= await mediator.Send(searchEntryQuery);
            return Ok(result);
        }
    }
}