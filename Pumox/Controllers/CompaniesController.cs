using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Pumox.Application.Commands;
using Pumox.Application.Dtos;
using Pumox.Application.Queries;
using Pumox.Core.Domain;
using Pumox.Infrastructure.CQS.Commands;
using Pumox.Infrastructure.CQS.Queries;
using Pumox.Infrastructure.EntityFramework;
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
		private readonly ApplicationDbContext _context;

		public CompaniesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ApplicationDbContext context)
		{
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;
			_context = context;

			//if (!context.Companies.Any())
			//{
			//	_context.Companies.AddRange(
			//		new Company
			//		{
			//			Id = 1,
			//			Name = "Company1",
			//			EstablishmentYear = 2000,
			//		},
			//		new Company
			//		{
			//			Id = 2,
			//			Name = "Company2",
			//			EstablishmentYear = 2001,
			//			Employees = new List<Employee>
			//			{
			//				new Employee
			//				{
			//					Id = 1,
			//					FirstName = "First1",
			//					LastName = "Last1",
			//					DateOfBirth = new DateTime(1980, 12, 12),
			//					JobTitle = JobTitle.Administrator
			//				},
			//				new Employee
			//				{
			//					Id = 2,
			//					FirstName = "First2",
			//					LastName = "Last2",
			//					DateOfBirth = new DateTime(1990, 10, 07),
			//					JobTitle = JobTitle.Architect
			//				}
			//			}
			//		},
			//		new Company
			//		{
			//			Id = 3,
			//			Name = "Company3",
			//			EstablishmentYear = 2010,
			//			Employees = new List<Employee>
			//			{
			//				new Employee
			//				{
			//					Id = 3,
			//					FirstName = "First1",
			//					LastName = "Last6",
			//					DateOfBirth = new DateTime(2000, 08, 10),
			//					JobTitle = JobTitle.Administrator
			//				},
			//				new Employee
			//				{
			//					Id = 4,
			//					FirstName = "First4",
			//					LastName = "Last5",
			//					DateOfBirth = new DateTime(2004, 01, 17),
			//					JobTitle = JobTitle.Developer
			//				}
			//			}
			//		}
			//	);
			//	_context.SaveChanges();
			//}
		}

		[HttpPost("search")]
		public async Task<IActionResult> Post(SearchCompanyQuery query)
		{
			var result = await _queryDispatcher.Dispatch(query);
			var x = (IEnumerable<CompanyDto>)result.Data;
			return Ok(x);
		}

		[HttpPost("create")]
		public async Task<IActionResult> Post(CompanyDto dto)
		{
			var result = await _commandDispatcher.Dispatch(new CreateCompanyCommand { CompanyDto = dto });

			if (!result.Succeeded)
				return BadRequest();

			return Created(string.Empty, null);
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
		public async Task<IActionResult> Delete(long id)
		{
			var result = await _commandDispatcher.Dispatch(new DeleteCompanyCommand { CompanyId = id });

			if (!result.Succeeded)
				return BadRequest();

			return NoContent();
		}
	}
}
