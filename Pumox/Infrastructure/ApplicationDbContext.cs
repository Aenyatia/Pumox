﻿using Microsoft.EntityFrameworkCore;
using Pumox.Domain;

namespace Pumox.Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }

		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}
