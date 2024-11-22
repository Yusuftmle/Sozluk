using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace BlazerSozluk.Infrastructure.Persistence.Repositories
{
	public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfimationRepository
	{
		public EmailConfirmationRepository(BlazerSozlukContext dbContext) : base(dbContext, dbContext.Set<EmailConfirmation>())
		{
		}
	}

}
