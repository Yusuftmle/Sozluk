﻿using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BlazerSozluk.Api.WebApi.Infrastructure.Extenions
{
	public static class AuthRegistration
	{
         public static IServiceCollection ConfigureAuth (this IServiceCollection services ,IConfiguration configuration)
		{
			var options = new JsonSerializerOptions()
			{
				ReferenceHandler = ReferenceHandler.Preserve,
				PropertyNameCaseInsensitive = true
			};
			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AuthConfig:Secret"]));
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			 .AddJwtBearer(options =>
			 {
				 options.TokenValidationParameters = new TokenValidationParameters()
				 {
					 ValidateIssuer = false,
					 ValidateAudience = false,
					 ValidateLifetime = true,
					 ValidateIssuerSigningKey = true,
					 IssuerSigningKey = signingKey
				 };
			 });

			return services;
		}   
	}
}
