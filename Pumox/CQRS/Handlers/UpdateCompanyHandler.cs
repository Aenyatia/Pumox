using Pumox.CQRS.Commands;
using Pumox.CQRS.Core;
using Pumox.CQRS.Core.Command;
using System;
using System.Threading.Tasks;

namespace Pumox.CQRS.Handlers
{
	public class UpdateCompanyHandler : ICommandHandler<UpdateCompanyCommand>
	{
		public Task<IResult> Handle(UpdateCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
