using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.Model.Interfaces
{
    interface ISearcher
    {
        /// <summary>
        /// Searches to find a specific first name
        /// </summary>
        /// <param name="firstName">The first name in question</param>
        /// <returns>The items index</returns>
        /// <remarks>In C#, an irrational(floating point) number is always rounded down</remarks>
        int SearchForFirstName(IList<Person> collectionToSearch, string firstName);
    }
}
