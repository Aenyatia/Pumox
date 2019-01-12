using Pumox.Application.Dtos;
using Pumox.Application.Queries;
using Pumox.Core.Domain;
using System.Linq;
using System.Threading.Tasks;
using Pumox.Common.CQS.Queries;
using Pumox.Common.CQS.Results;
using Pumox.Common.Specifications;
using Pumox.Common.Specifications.Core;
using Pumox.Core.Companies;
using Pumox.Core.Shared;

namespace Pumox.Application.QueriesHandlers
{
	public class SearchCompanyQueryHandler : IQueryHandler<SearchCompanyQuery>
	{
		private readonly IUnitOfWork _unitOfWork;

		public SearchCompanyQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IQueryResult> Handle(SearchCompanyQuery query)
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

			var result = await _unitOfWork.Companies.Get(specification);
			var resultDto = result.Select(c => new CompanyDto
			{
				Name = c.Name,
				EstablishmentYear = c.EstablishmentYear,
				Employees = c.Employees.Select(e => new EmployeeDto
				{
					FirstName = e.FirstName,
					LastName = e.LastName,
					DateOfBirth = e.DateOfBirth,
					JobTitle = e.JobTitle
				})
			});

			return new QueryResult { Data = resultDto };
		}
	}
}
