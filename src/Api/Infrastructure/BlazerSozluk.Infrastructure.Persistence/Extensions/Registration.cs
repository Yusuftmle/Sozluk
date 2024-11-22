using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.Infrastructure.Persistence.Context;
using BlazerSozluk.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazerSozluk.Infrastructure.Persistence.Extensions
{
    public static class  Registration
    {
        public static IServiceCollection AddInfrastructureRegistration (this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BlazerSozlukContext>(conf =>
            {
                var conStr = configuration["BlazorSozlukDbConnectionStrings"];
                conf.UseSqlServer(conStr);
            });


			// var seedData = new SeedData();
			// seedData.seedAsync(configuration).GetAwaiter().GetResult();
			
			services.AddTransient<IUserRepository,UserRepository> ();
            services.AddTransient<IEmailConfimationRepository , EmailConfirmationRepository>();
            services.AddTransient<IEntryRepository,EntryRepository>();
            services.AddTransient<IEntryCommentRepository, EntryCommentRepository>();
            return services;
        }
    }
}
