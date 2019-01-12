using Pumox.Application.Dtos;
using Pumox.Common.CQS.Commands;

namespace Pumox.Application.Commands
{
	public class UpdateCompanyCommand : ICommand
	{
		public long Id { get; set; }
		public CompanyDto CompanyDto { get; set; }
	}
}
