using System;
using System.Collections.Generic;
using Pumox.Domain;

namespace Pumox
{
	public class SearchCriteria
	{
		public string Keyword { get; set; }
		public DateTime? DateFrom { get; set; }
		public DateTime? DateTo { get; set; }
		public IEnumerable<JobTitle> Titles { get; set; } = new List<JobTitle>();
	}
}
