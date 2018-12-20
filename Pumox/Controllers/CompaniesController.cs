﻿using Microsoft.AspNetCore.Mvc;
using Pumox.CQS.Commands;
using Pumox.CQS.Core.Command;
using Pumox.CQS.Core.Query;
using Pumox.CQS.Queries;

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

		[HttpGet("search")]
		public IActionResult Post(SearchCompanyQuery query)
		{
			var result = _queryDispatcher.Dispatch(query);

			return Ok();
		}

		[HttpPost("create")]
		public IActionResult Post(CreateCompanyCommand command)
		{
			var result = _commandDispatcher.Dispatch(command);

			return Created(string.Empty, null);
		}

		[HttpPut("update/{id:long}")]
		public IActionResult Put(long id, UpdateCompanyCommand command)
		{
			var result = _commandDispatcher.Dispatch(command);

			return NoContent();
		}

		[HttpDelete("delete/{id:long}")]
		public IActionResult Delete(long id, DeleteCompanyCommand command)
		{
			var result = _commandDispatcher.Dispatch(command);

			return NoContent();
		}
	}
}
