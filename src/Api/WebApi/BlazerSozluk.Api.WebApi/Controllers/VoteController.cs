using BlazerSozluk.Api.Application.Features.Commands.Entry.DeleteVote;
using BlazerSozluk.Api.Application.Features.Commands.EntryComment.CreateVote;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.common.Models.RequestModels;
using BlazerSozluk.common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazerSozluk.Api.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class VoteController : BaseController
	{
		private readonly IMediator Mediator;

		public VoteController(IMediator mediator)
		{
			Mediator = mediator;
		}

		[HttpPost]
		[Route("Entry/{entryId}")]
		public async Task<IActionResult> CreateEntryVote(Guid entryId, VoteType voteType = VoteType.UpVote)
		{
			var result = await Mediator.Send(new CreateEntryVoteCommand(entryId, voteType, UserId.Value));
			return Ok(result);
		}

		[HttpPost]
		[Route("EntryComment/{entryCommentId}")]
		public async Task<IActionResult> CreateEntryCommentVote(Guid entryCommentId, VoteType voteType = VoteType.UpVote)
		{
			var result = await Mediator.Send(new CreateEntryCommentVoteCommand(entryCommentId, voteType, UserId.Value));
			return Ok(result);
		}

		[HttpPost]
		[Route("DeleteEntryVote/{entryId}")]
		public async Task<IActionResult> DeleteEntryVote(Guid entryId)
		{
			await Mediator.Send(new DeleteEntryVoteCommand(entryId, UserId.Value));
			return Ok();
		}

	}
}
