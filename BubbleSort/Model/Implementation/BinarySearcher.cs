
using SortingAndSearching.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAndSearching.Model.Implementation
{
    /// <summary>
    /// Uses binary search to find a first name
    /// </summary>
    public class BinarySearcher : ISearcher
    {
        public int SearchForFirstName(IList<Person> collectionToSearch, string firstName)
        {
            int listSize = collectionToSearch.Count();
            int middle = (listSize / 2);
            int floor = 0;
            int ceiling = listSize - 1;
            string[] names = collectionToSearch.Select(x => x.FirstName).ToArray();

            bool found = false;

            while (!found)
            {
                int equalityNumber = string.Compare(names[middle], firstName, StringComparison.CurrentCultureIgnoreCase);
                if ((ceiling - floor) == 1)
                {
                    return (string.Compare(names[ceiling], firstName, StringComparison.CurrentCultureIgnoreCase) == 0 ? ceiling : floor);
                }
                if (equalityNumber == 0)
                {
                    found = true;
                    return middle;
                }
                else if (equalityNumber > 0)
                {
                    ceiling = middle - 1;
                }
                else
                {
                    floor = middle + 1;
                }

                if ((ceiling - floor) < 0) break;

                middle = (ceiling + floor) / 2;
            }
            return -1;
        }
    }
}
