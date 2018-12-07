using System;
using System.Threading.Tasks;
using Pumox.CommandsQueries.Commands;
using Pumox.CommandsQueries.Core;
using Pumox.CommandsQueries.Core.Command;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Handlers
{
	public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
	{
		private readonly ICompanyRepository _companyRepository;

		public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
		{
			_companyRepository = companyRepository;
		}

		public Task<IResult> Handle(DeleteCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
