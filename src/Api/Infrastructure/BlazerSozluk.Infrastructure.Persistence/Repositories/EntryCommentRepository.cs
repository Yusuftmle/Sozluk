using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.Infrastructure.Persistence.Repositories
{
	public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
	{
		public EntryCommentRepository(BlazerSozlukContext dbContext) : base(dbContext, dbContext.Set<EntryComment>())
		{
		}
	}
}
