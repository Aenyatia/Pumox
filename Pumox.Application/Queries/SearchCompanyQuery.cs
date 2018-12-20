using Pumox.Core.Domain;
using Pumox.Infrastructure.CQS.Queries;
using System;
using System.Collections.Generic;

namespace Pumox.Application.Queries
{
	public class SearchCompanyQuery : IQuery
	{
		public string Keyword { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public IEnumerable<JobTitle> Titles { get; set; }
	}
}
