using BlazerSozluk.Api.Application.Features.Commands.User.ConfirmEmail;
using BlazerSozluk.Api.Application.Features.Queries.GetUserDetail;
using BlazerSozluk.common.Events.User;
using BlazerSozluk.common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazerSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	
	public class UserController : BaseController
    {
        
        private readonly IMediator mediator;
      
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
            var user = await mediator.Send(new GetUserDetailQuery(id, string.Empty));

			return Ok(user);
		}

		[HttpGet]
		[Route("UserName/{userName}")]
		public async Task<IActionResult> GetByUserName(string userName)
		{
			var user = await mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));

			return Ok(user);
		}


		[HttpPost]
        [Route("Login")]
    
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var res = await mediator.Send(command);
            return Ok(res);

        }

		


		[HttpPost]
		
		public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var guid = await mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Update")]
		[Authorize]
		public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var guid = await mediator.Send(command);
            return Ok(guid);
        }

        [HttpPost]
        [Route("Confirm")]
		[Authorize]
		public async Task<IActionResult> ConfirmEmail(Guid Id)
        {
            var guid = await mediator.Send(new ConfirmEmailCommand() { ConfirmationId = Id });
            return Ok(guid);
        }

        [HttpPost]
        [Route("Change Password")]
		[Authorize]
		public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
        {
            if (!command.UserId.HasValue)
                command.UserId = UserId;
            var guid = await mediator.Send(command);
            return Ok(guid);
        }

    }
}
