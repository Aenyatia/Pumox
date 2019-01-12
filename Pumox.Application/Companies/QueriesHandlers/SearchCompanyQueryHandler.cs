using Pumox.Application.Companies.Queries;
using Pumox.Common.CQS.Queries;
using Pumox.Common.CQS.Results;
using Pumox.Common.Specifications.Core;
using Pumox.Core.Companies;
using System.Threading.Tasks;

namespace Pumox.Application.Companies.QueriesHandlers
{
	public class SearchCompanyQueryHandler : IQueryHandler<SearchCompanyQuery>
	{
		public SearchCompanyQueryHandler()
		{

		}

		public async Task<IQueryResult> Handle(SearchCompanyQuery query)
		{
			var specification = Specification<Company>.AllTrue;

			//if (!string.IsNullOrWhiteSpace(query.Keyword))
			//{
			//	specification = specification.And(new CompanyNameSpecification(query.Keyword));
			//	specification = specification.And(new EmployeeFirstNameSpecification(query.Keyword));
			//	specification = specification.And(new EmployeeLastNameSpecification(query.Keyword));
			//}

			//if (query.DateFrom.HasValue)
			//{
			//	specification.And(new EmployeeBirthFromSpecification(query.DateFrom.Value));
			//}

			//if (query.DateTo.HasValue)
			//{
			//	specification.And(new EmployeeBirthToSpecification(query.DateTo.Value));
			//}

			//if (query.Titles.Any())
			//{
			//	var jobsSpec = Specification<Company>.AllFalse;
			//	foreach (var jobTitle in query.Titles)
			//	{
			//		jobsSpec = jobsSpec.Or(new EmployeeJobTitle(jobTitle));
			//	}

			//	specification = specification.And(jobsSpec);
			//}

			//var result = await _unitOfWork.Companies.Get(specification);
			//var resultDto = result.Select(c => new CompanyDto
			//{
			//	Name = c.Name,
			//	EstablishmentYear = c.EstablishmentYear,
			//	Employees = c.Employees.Select(e => new EmployeeDto
			//	{
			//		FirstName = e.FirstName,
			//		LastName = e.LastName,
			//		DateOfBirth = e.DateOfBirth,
			//		JobTitle = e.JobTitle
			//	})
			//});

			await Task.CompletedTask;
			return null;
		}
	}
}
