using Microsoft.AspNetCore.Mvc;
using Pumox.Application.Companies.Commands;
using Pumox.Application.Companies.Queries;
using Pumox.Common.CQS.Commands;
using Pumox.Common.CQS.Queries;
using System;
using System.Threading.Tasks;

namespace Pumox.Controllers
{
	[Route("company")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryDispatcher _queryDispatcher;

		public CompaniesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
		{
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;
		}

		[HttpPost("search")]
		public async Task<IActionResult> Post(SearchCompanyQuery query)
		{
			var result = await _queryDispatcher.Dispatch(query);
			return Ok(result);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Post(CreateCompany command)
		{
			command.Id = Guid.NewGuid();
			await _commandDispatcher.Dispatch(command);

			return Created(command.Id.ToString(), command.Id.ToString());
		}

		[HttpPut("update/{id}")]
		public async Task<IActionResult> Put(Guid id, UpdateCompany command)
		{
			command.Id = id;
			await _commandDispatcher.Dispatch(command);

			return NoContent();
		}

		[HttpDelete("delete/{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _commandDispatcher.Dispatch(new DeleteCompany { Id = id });

			return NoContent();
		}
	}
}
