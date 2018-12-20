using Pumox.Infrastructure.CQS.Results;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.CQS.Queries
{
	public interface IQueryHandler<in TQuery> where TQuery : IQuery
	{
		Task<IQueryResult> Handle(TQuery query);
	}
}
