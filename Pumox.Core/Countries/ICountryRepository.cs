using System;
using System.Threading.Tasks;

namespace Pumox.Core.Countries
{
	public interface ICountryRepository
	{
		Task<Country> GetCountryById(Guid id);
	}
}
