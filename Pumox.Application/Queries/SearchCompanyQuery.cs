using Pumox.Core.Domain;
using System;
using System.Collections.Generic;
using Pumox.Common.CQS.Queries;
using Pumox.Core.Employees;

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
