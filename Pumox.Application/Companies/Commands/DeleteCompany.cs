using Pumox.Common.CQS.Commands;
using System;

namespace Pumox.Application.Companies.Commands
{
	public class DeleteCompany : ICommand
	{
		public Guid Id { get; set; }
	}
}
