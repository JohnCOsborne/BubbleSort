using SortingAndSearching.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace SortingAndSearching.Model.Implementation
{
    public class BubleSorter : ISorter
    {
        public void SortAlphabetically(ref IList<Person> collectionToSort)
        {
            bool finished = false;
            int changes = 0;
            int length = collectionToSort.Count;
            while (!finished)
            {
                changes = 0;
                for (int i = 0; i + 1 < length; i++)
                {
                    Person first = collectionToSort[i] as Person;
                    Person second = collectionToSort[i + 1] as Person;
                    if (String.Compare(first.FirstName, second.FirstName, StringComparison.CurrentCultureIgnoreCase) > 0)
                    {
                        collectionToSort[i] = second;
                        collectionToSort[i + 1] = first;
                        changes++;
                    }
                }
                if (changes == 0) finished = true;
            }
        }
    }
}
