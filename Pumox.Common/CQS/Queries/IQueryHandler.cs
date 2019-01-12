using System.Threading.Tasks;
using Pumox.Common.CQS.Results;

namespace Pumox.Common.CQS.Queries
{
	public interface IQueryHandler<in TQuery> where TQuery : IQuery
	{
		Task<IQueryResult> Handle(TQuery query);
	}
}
