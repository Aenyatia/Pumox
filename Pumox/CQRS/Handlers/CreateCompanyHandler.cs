﻿using Pumox.CQRS.Commands;
using Pumox.CQRS.Core;
using Pumox.CQRS.Core.Command;
using System;
using System.Threading.Tasks;

namespace Pumox.CQRS.Handlers
{
	public class CreateCompanyHandler : ICommandHandler<CreateCompanyCommand>
	{
		public Task<IResult> Handle(CreateCompanyCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
