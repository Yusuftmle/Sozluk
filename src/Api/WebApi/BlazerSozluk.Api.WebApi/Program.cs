
using BlazerSozluk.Api.Application.Extensions;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.Api.WebApi.Infrastructure.ActionFilters;
using BlazerSozluk.Api.WebApi.Infrastructure.Extenions;
using BlazerSozluk.Infrastructure.Persistence.Context;
using BlazerSozluk.Infrastructure.Persistence.Extensions;
using BlazerSozluk.Infrastructure.Persistence.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Scrutor;

namespace BlazerSozluk.Api.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var configuration = builder.Configuration;
            builder.Services.AddControllers(opt => opt.Filters.Add<ValidateModelStateFilter>())
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddFluentValidation()
                .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

           

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAplicationRegistration();
            builder.Services.AddInfrastructureRegistration(builder.Configuration);
            builder.Services.ConfigureAuth(builder.Configuration);
           
			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

			app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
           

            app.MapControllers();

            app.Run();
        }
    }
}