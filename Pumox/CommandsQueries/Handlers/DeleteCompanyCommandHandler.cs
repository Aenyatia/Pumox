using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;
using System.Threading.Tasks;

namespace Pumox.CommandsQueries.Handlers
{
	public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IResult> Handle(DeleteCompanyCommand command)
		{
			var company = _unitOfWork.Companies.GetCompanyById(command.CompanyId);
			if (company == null)
				return new Result();

			_unitOfWork.Companies.Remove(company);
			_unitOfWork.Commit();

			await Task.CompletedTask;

			return new Result();
		}
	}
}
