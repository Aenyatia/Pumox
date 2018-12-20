using System.Threading.Tasks;

namespace Pumox.CQS.Core.Query
{
	public interface IQueryDispatcher
	{
		Task<IResult> Dispatch<TQuery>(TQuery query) where TQuery : IQuery;
	}
}
