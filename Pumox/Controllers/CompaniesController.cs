using Microsoft.AspNetCore.Mvc;
using Pumox.Application.Commands;
using Pumox.Application.Dtos;
using Pumox.Application.Queries;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Queries;
using System;
using System.Collections.Generic;
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
			var x = (IEnumerable<CompanyDto>)result.Data;
			return Ok(x);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Post(CreateCompanyCommand command)
		{
			command.Id = Guid.NewGuid();
			var result = await _commandDispatcher.Dispatch(command);

			if (!result.Succeeded)
				return BadRequest(result.Errors);

			return Created(string.Empty, command.Id);
		}

		[HttpPut("update/{id:long}")]
		public async Task<IActionResult> Put(long id, CompanyDto dto)
		{
			var result = await _commandDispatcher.Dispatch(new UpdateCompanyCommand
			{
				Id = id,
				CompanyDto = dto
			});

			if (!result.Succeeded)
				return BadRequest();

			return NoContent();
		}

		[HttpDelete("delete/{id:long}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _commandDispatcher.Dispatch(new DeleteCompanyCommand { CompanyId = id });

			if (!result.Succeeded)
				return BadRequest();

			return NoContent();
		}
	}
}
