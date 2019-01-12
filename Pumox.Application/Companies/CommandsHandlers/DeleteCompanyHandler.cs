using System.Threading.Tasks;
using Pumox.Application.Companies.Commands;
using Pumox.Common.CQS.Commands;
using Pumox.Core.Companies;

namespace Pumox.Application.Companies.CommandsHandlers
{
	public class DeleteCompanyHandler : ICommandHandler<DeleteCompany>
	{
		private readonly ICompanyService _companyService;

		public DeleteCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task Handle(DeleteCompany command)
		{
			await _companyService.Delete(command.Id);
		}
	}
}
