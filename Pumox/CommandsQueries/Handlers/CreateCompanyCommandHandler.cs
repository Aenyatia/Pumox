using System;
using System.Threading.Tasks;
using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Handlers
{
	public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
	{
		private readonly ICompanyRepository _companyRepository;

		public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public Task<IResult> Handle(CreateCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
