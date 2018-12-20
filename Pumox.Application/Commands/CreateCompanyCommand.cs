using Pumox.Application.Dtos;
using Pumox.Infrastructure.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class CreateCompanyCommand : ICommand
	{
		public CompanyDto CompanyDto { get; set; }
	}
}
