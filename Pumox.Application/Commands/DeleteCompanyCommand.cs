using System;
using Pumox.Infrastructure.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public Guid CompanyId { get; set; }
	}
}
