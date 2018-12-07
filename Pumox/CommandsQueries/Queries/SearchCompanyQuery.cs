using System;
using System.Collections.Generic;
using Pumox.CommandsQueries.Core.Query;
using Pumox.Domain;

namespace Pumox.CommandsQueries.Queries
{
	public class SearchCompanyQuery : IQuery
	{
		public string Keyword { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public IEnumerable<JobTitle> Titles { get; set; }
	}
}
