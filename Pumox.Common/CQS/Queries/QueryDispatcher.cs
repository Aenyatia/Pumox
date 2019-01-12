using System;
using System.Threading.Tasks;
using Pumox.Common.CQS.Results;

namespace Pumox.Common.CQS.Queries
{
	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly IComponentContext _componentContext;

		public QueryDispatcher(IComponentContext componentContext)
		{
			_componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
		}

		public async Task<IQueryResult> Dispatch<TQuery>(TQuery query) where TQuery : IQuery
		{
			if (query == null)
				throw new ArgumentNullException(nameof(query));

			var handler = _componentContext.Resolve<IQueryHandler<TQuery>>();

			return await handler.Handle(query);
		}
	}
}
