using System;
using Pumox.Common.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class DeleteCompanyCommand : ICommand
	{
		public Guid CompanyId { get; set; }
	}
}
