using System.Linq;
using System.Threading.Tasks;
using Pumox.CQS.Core;
using Pumox.CQS.Core.Query;
using Pumox.CQS.Queries;
using Pumox.Domain;
using Pumox.Specifications;
using Pumox.Specifications.Core;

namespace Pumox.CQS.Handlers
{
	public class SearchCompanyQueryHandler : IQueryHandler<SearchCompanyQuery>
	{
		private readonly IUnitOfWork _unitOfWork;

		public SearchCompanyQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IResult> Handle(SearchCompanyQuery query)
		{
			var specification = Specification<Company>.AllTrue;

			if (!string.IsNullOrWhiteSpace(query.Keyword))
			{
				specification = specification.And(new CompanyNameSpecification(query.Keyword));
				specification = specification.And(new EmployeeFirstNameSpecification(query.Keyword));
				specification = specification.And(new EmployeeLastNameSpecification(query.Keyword));
			}

			if (query.DateFrom.HasValue)
			{
				specification.And(new EmployeeBirthFromSpecification(query.DateFrom.Value));
			}

			if (query.DateTo.HasValue)
			{
				specification.And(new EmployeeBirthToSpecification(query.DateTo.Value));
			}

			if (query.Titles.Any())
			{
				var jobsSpec = Specification<Company>.AllFalse;
				foreach (var jobTitle in query.Titles)
				{
					jobsSpec = jobsSpec.Or(new EmployeeJobTitle(jobTitle));
				}

				specification = specification.And(jobsSpec);
			}

			var result = _unitOfWork.Companies.Get(specification);


			await Task.CompletedTask;
			return new Result();
		}
	}
}
