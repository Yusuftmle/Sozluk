using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazerSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
		public Guid? UserId
		{
			get
			{
				var val = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				return val is null ? null : new Guid(val);
			}
		}
	}
}
