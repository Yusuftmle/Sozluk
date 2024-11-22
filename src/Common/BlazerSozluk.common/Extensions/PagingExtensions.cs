using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Models.Page;
using Microsoft.EntityFrameworkCore;

namespace BlazerSozluk.common.Extensions
{
	public static class PagingExtensions
	{
		public static async Task<PagedViewModel<T>> GetPaged<T>(this IQueryable<T> query,
			                                               int currentPage,
														   int PageSize) where T : class
		{

			var count=await query.CountAsync();

			Page paging =new (currentPage, PageSize, count);

			var data=await query.Skip(paging.skip).Take(paging.pageSize).AsNoTracking().ToListAsync();

			var result = new PagedViewModel<T>(data, paging);
			return result;

		}
			                                  
	
	}
}
