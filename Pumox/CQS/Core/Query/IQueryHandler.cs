using System.Threading.Tasks;

namespace Pumox.CQS.Core.Query
{
	public interface IQueryHandler<in TQuery> where TQuery : IQuery
	{
		Task<IResult> Handle(TQuery query);
	}
}
