using Pumox.Application.Companies.Commands;
using Pumox.Common.CQS.Commands;
using Pumox.Core.Companies;
using System.Threading.Tasks;

namespace Pumox.Application.Companies.Handlers
{
	public class CreateCompanyHandler : ICommandHandler<CreateCompany>
	{
		private readonly ICompanyService _companyService;

		public CreateCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task Handle(CreateCompany command)
		{
			var company = new Company(command.Id, command.Name, command.EstablishmentYear);
			company.SetEmployees(company.Employees);

			await _companyService.Add(company);
		}
	}
}
