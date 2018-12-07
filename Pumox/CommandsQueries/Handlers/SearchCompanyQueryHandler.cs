using System;
using System.Threading.Tasks;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Query;
using Pumox.CommandsQueries.Queries;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Handlers
{
	public class SearchCompanyQueryHandler : IQueryHandler<SearchCompanyQuery>
	{
		private readonly ICompanyRepository _companyRepository;

		public SearchCompanyQueryHandler(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public Task<IResult> Handle(SearchCompanyQuery query)
		{
			throw new NotImplementedException();
		}
	}
}
