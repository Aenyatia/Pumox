using System;
using System.Threading.Tasks;

namespace Pumox.CQS.Core.Query
{
	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly Func<Type, IQueryHandler<IQuery>> _handlersFactory;

		public QueryDispatcher(Func<Type, IQueryHandler<IQuery>> handlersFactory)
		{
			_handlersFactory = handlersFactory;
		}

		public async Task<IResult> Dispatch<TQuery>(TQuery query) where TQuery : IQuery
		{
			var handler = _handlersFactory(typeof(TQuery));
			return await handler.Handle(query);
		}
	}
}
