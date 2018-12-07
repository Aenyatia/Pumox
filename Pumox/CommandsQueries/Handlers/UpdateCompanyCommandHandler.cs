using System;
using System.Threading.Tasks;
using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Handlers
{
	public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
	{
		private readonly ICompanyRepository _companyRepository;

		public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public Task<IResult> Handle(UpdateCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
