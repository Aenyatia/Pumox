using Pumox.CQRS.Core.Query;
using Pumox.Domain;
using System;
using System.Collections.Generic;

namespace Pumox.CQRS.Queries
{
	public class SearchCompanyQuery : IQuery
	{
		public string Keyword { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public IEnumerable<JobTitle> Titles { get; set; }
	}
}
