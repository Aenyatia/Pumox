using Pumox.Application.Commands;
using Pumox.Core.Repositories;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Results;
using System.Threading.Tasks;

namespace Pumox.Application.CommandsHandlers
{
	public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ICommandResult> Handle(DeleteCompanyCommand command)
		{
			var company = await _unitOfWork.Companies.GetCompanyById(command.CompanyId);
			if (company == null)
				return CommandResult.Fail("Company not found.");

			await _unitOfWork.Companies.Remove(company);
			await _unitOfWork.Commit();

			return CommandResult.Ok();
		}
	}
}
