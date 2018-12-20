using System.Threading.Tasks;
using Pumox.CQS.Commands;
using Pumox.CQS.Core;
using Pumox.CQS.Core.Command;
using Pumox.Domain;

namespace Pumox.CQS.Handlers
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
