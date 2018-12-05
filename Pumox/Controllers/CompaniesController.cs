using Microsoft.AspNetCore.Mvc;
using Pumox.Commands;
using Pumox.Services;

namespace Pumox.Controllers
{
	[Route("company")]
	[ApiController]
	public class CompaniesController : ControllerBase
	{
		private readonly CompanyService _companyService;

		public CompaniesController(CompanyService companyService)
		{
			_companyService = companyService;
		}

		// test method
		[HttpGet]
		public IActionResult Get()
		{
			var companies = _companyService.Get();
			return Ok(companies);
		}

		[HttpPost("search")]
		public IActionResult Post()
		{
			return Ok();
		}

		[HttpPost("create")]
		public IActionResult Post(CreateCompany command)
		{
			var company = _companyService.CreateCompany(command);

			return Created(string.Empty, company.Id);
		}

		[HttpPut("update/{id:long}")]
		public IActionResult Put(long id, UpdateCompany company)
		{
			_companyService.UpdateCompany(id, company);

			return NoContent();
		}

		[HttpDelete("delete/{id:long}")]
		public IActionResult Delete(long id)
		{
			_companyService.DeleteCompany(id);

			return NoContent();
		}
	}
}
