using Pumox.CQRS.Commands;
using Pumox.CQRS.Core;
using Pumox.CQRS.Core.Command;
using System;
using System.Threading.Tasks;

namespace Pumox.CQRS.Handlers
{
	public class DeleteCompanyHandler : ICommandHandler<DeleteCompanyCommand>
	{
		public Task<IResult> Handle(DeleteCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
