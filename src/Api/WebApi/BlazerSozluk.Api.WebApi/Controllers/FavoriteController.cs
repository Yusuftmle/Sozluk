using BlazerSozluk.Api.Application.Features.Commands.Entry.CreateFav;
using BlazerSozluk.Api.Application.Features.Commands.EntryCommand.CreateFav;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazerSozluk.Api.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FavoriteController : BaseController
	{
		private readonly IMediator mediator;

		public FavoriteController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpPost]
		[Route("entry/{entryId}")]

		public async Task<IActionResult> CreateEntryFav(Guid entryId)
		{
			if (!UserId.HasValue)
			{
				return Unauthorized("User ID cannot be determined.");
			}

			var result = await mediator.Send(new CreateEntryFavCommand(entryId, UserId.Value));
			return Ok(result);
		}
		[HttpPost]
		[Route("entryComment/{entryCommentId}")]

		public async Task<IActionResult> CreateEntryCommentFav(Guid entryCommentId)
		{
			if (!UserId.HasValue)
			{
				return Unauthorized("User ID cannot be determined.");
			}
			var result = await mediator.Send(new deleteentryCommentFavCommand(entryCommentId, UserId.Value));
			return Ok(result);
		}
		[HttpPost]
		[Route("deleteentryFav/{entryId}")]

		public async Task<IActionResult> deleteentryFav(Guid entryId)
		{
			if (!UserId.HasValue)
			{
				return Unauthorized("User ID cannot be determined.");
			}
			var result = await mediator.Send(new deleteentryCommentFavCommand(entryId, UserId.Value));
			return Ok(result);
		}

		[HttpPost]
		[Route("deleteentryCommentFav/{entryCommentId}")]

		public async Task<IActionResult> deleteentryCommentFav(Guid entryCommentId)
		{
			if (!UserId.HasValue)
			{
				return Unauthorized("User ID cannot be determined.");
			}
			var result = await mediator.Send(new deleteentryCommentFavCommand(entryCommentId, UserId.Value));
			return Ok(result);
		}


	}
}
