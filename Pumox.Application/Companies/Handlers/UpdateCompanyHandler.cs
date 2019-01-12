using Pumox.Application.Companies.Commands;
using Pumox.Common.CQS.Commands;
using System.Threading.Tasks;
using Pumox.Core.Companies;

namespace Pumox.Application.Companies.Handlers
{
	public class UpdateCompanyHandler : ICommandHandler<UpdateCompany>
	{
		private readonly ICompanyService _companyService;

		public UpdateCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task Handle(UpdateCompany command)
		{
			var company = _companyService.
		}
	}
}
