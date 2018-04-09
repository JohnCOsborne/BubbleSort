using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortingAndSearching
{
    /// <summary>
    /// Provides a list and the abilities to search and sort it
    /// </summary>
    public class ListProvider
    {
        //Private fields
        private StreamReader fileReader;

        #region Properties
        public List<Person> TheList{ get; set;}
        #endregion

        public ListProvider()
        {
            //default constructor for tests
        }

        /// <summary>
        /// Constructor for ListProvider
        /// </summary>
        /// <param name="fileName">The file path to read the names from</param>
        public ListProvider(string fileName)
        {
            TheList = new List<Person>();
            using (fileReader = new StreamReader(fileName))
            {
                String line = string.Empty;
                while (fileReader.Peek() != -1)
                {
                    line = fileReader.ReadLine();
                    String[] nameArray = line.Split(' ');

                    TheList.Add(new Person(nameArray[0], nameArray[1]));
                }
            }
        }

        /// <summary>
        /// Sorts the list alphabetically using bubble sort
        /// </summary>
        public void SortWithBubbleSortAlphabetically()
        {
            bool finished = false;
            int changes = 0;
            int length = TheList.Count;
            while (!finished)
            {
                changes = 0;
                for (int i = 0; i + 1 < length; i++)
                {
                    Person first = TheList[i] as Person;
                    Person second = TheList[i + 1] as Person;
                    if (String.Compare(first.FirstName, second.FirstName, StringComparison.CurrentCultureIgnoreCase) > 0)
                    {
                        TheList[i] = second;
                        TheList[i + 1] = first;
                        changes++;
                    }
                }
                if (changes == 0) finished = true;
            }
        }

        /// <summary>
        /// Uses binary search to find a specific first name
        /// </summary>
        /// <param name="firstName">The first name in question</param>
        /// <returns>The items index</returns>
        /// <remarks>In C#, an irrational(floating point) number is always rounded down</remarks>
        public int BinarySearch(string firstName)
        {
            int listSize = TheList.Count();
            int middle = (listSize / 2);
            int floor = 0;
            int ceiling = listSize - 1;
            string[] names = TheList.Select(x => x.FirstName).ToArray();

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

        public void QuickSort()
        {
            //choose pivot then sort around pivot
            string pivot = TheList.Last().FirstName;
            List<string> newList = new List<string>(45);
            newList[6] = "";
            foreach(string name in TheList.Select(x => x.FirstName))
            {
                int equalityNumber = String.Compare(name, pivot, StringComparison.CurrentCultureIgnoreCase);
                if (equalityNumber > 0)
                {
                    //put name to the right of pivot
                }else
                {
                    //put name to the left of pivot
                }
            }
        }
    }
}
