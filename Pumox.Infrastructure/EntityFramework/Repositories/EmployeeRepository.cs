using Microsoft.EntityFrameworkCore;
using Pumox.Core.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pumox.Infrastructure.EntityFramework.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ApplicationDbContext _context;

		public EmployeeRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Employee> GetEmployeeById(Guid id)
		{
			return await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
		}

		public async Task<IEnumerable<Employee>> GetAll()
		{
			return await _context.Employees.ToListAsync();
		}

		public async Task Add(Employee employee)
		{
			await _context.Employees.AddAsync(employee);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Employee employee)
		{
			_context.Employees.Update(employee);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Employee employee)
		{
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
		}
	}
}
