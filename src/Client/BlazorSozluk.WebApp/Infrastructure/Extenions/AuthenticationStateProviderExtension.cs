﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorSozluk.WebApp.Infrastructure.Extenions
{
	public static  class AuthenticationStateProviderExtension
	{
		public static async Task<Guid> GetUserId(this AuthenticationStateProvider provider)
		{
			var state=await provider.GetAuthenticationStateAsync();
			var userId = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			return !string.IsNullOrEmpty(userId) ? new Guid(userId) : Guid.Empty;


		}
	}
}
