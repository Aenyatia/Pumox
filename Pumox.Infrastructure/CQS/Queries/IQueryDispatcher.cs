using Pumox.Infrastructure.CQS.Results;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.CQS.Queries
{
	public interface IQueryDispatcher
	{
		Task<IQueryResult> Dispatch<TQuery>(TQuery query) where TQuery : IQuery;
	}
}
