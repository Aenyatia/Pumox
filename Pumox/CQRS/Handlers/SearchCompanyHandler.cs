using Pumox.CQRS.Core;
using Pumox.CQRS.Core.Query;
using Pumox.CQRS.Queries;
using System;
using System.Threading.Tasks;

namespace Pumox.CQRS.Handlers
{
	public class SearchCompanyHandler : IQueryHandler<SearchCompanyQuery>
	{
		public Task<IResult> Handle(SearchCompanyQuery query)
		{
			throw new NotImplementedException();
		}
	}
}
