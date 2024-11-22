using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazerSozluk.common.Models.Queries
{
	public class SearchEntryQuery:IRequest<List<SearchEntryViewModel>>
	{
        public SearchEntryQuery()
        {
        }

        public string SearchText { get; set; }
		public SearchEntryQuery(string searchText)
		{
			SearchText = searchText;
		}

		
	}
}
