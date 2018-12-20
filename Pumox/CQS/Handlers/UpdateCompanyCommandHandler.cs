using System.Threading.Tasks;
using Pumox.CQS.Commands;
using Pumox.CQS.Core;
using Pumox.CQS.Core.Command;
using Pumox.Domain;

namespace Pumox.CQS.Handlers
{
	public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
	{
		private readonly IUnitOfWork _unitOfWork;

		public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IResult> Handle(UpdateCompanyCommand command)
		{
			var id = 1;
			var company = _unitOfWork.Companies.GetCompanyById(1);
			if (company == null)
				return new Result();

			company.Name = company.Name;
			company.EstablishmentYear = company.EstablishmentYear;
			company.Employees = company.Employees;

			await Task.CompletedTask;
			_unitOfWork.Commit();

			return new Result();
		}
	}
}
