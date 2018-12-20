using Autofac;
using Pumox.Infrastructure.CQS.Results;
using System;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.CQS.Queries
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
