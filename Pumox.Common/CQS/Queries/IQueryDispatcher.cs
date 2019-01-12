using System.Threading.Tasks;
using Pumox.Common.CQS.Results;

namespace Pumox.Common.CQS.Queries
{
	public interface IQueryDispatcher
	{
		Task<IQueryResult> Dispatch<TQuery>(TQuery query) where TQuery : IQuery;
	}
}
