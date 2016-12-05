using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace BubbleSort
{
    /// <summary>
    /// Provides a list and the abilities to search and sort it
    /// </summary>
    public class ListProvider
    {
        //Private fields
        private StreamReader fileReader;
        private List<Person> theListOfNames;

        #region Properties
        public List<Person> TheList
        {
            get { return this.theListOfNames; }
            set { theListOfNames = value; }
        }
        #endregion

        public ListProvider()
        {
            //default constructor for tests
        }

        /// <summary>
        /// I wish C# had a Scanner class :/. How different are these languages really?
        /// </summary>
        /// <param name="fileName"></param>
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
        public void sortWithBubbleSortAlphabetically()
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
        /// <remarks>In C# a irrational(floating point) number is always rounded down</remarks>
        public int BinarySearch(string firstName)
        {
            int listSize = TheList.Count();
            int middle = listSize / 2 - 1;
            int floor = 0;
            int ceiling = listSize - 1;
            string[] names = TheList.Select(x => x.FirstName).ToArray<string>();

            bool found = false;

            while (!found)
            {
                int equalityNumber = String.Compare(names[middle], firstName, StringComparison.CurrentCultureIgnoreCase);
                if ((ceiling - floor) == 1)
                {
                    return (String.Compare(names[ceiling], firstName, StringComparison.CurrentCultureIgnoreCase) == 0 ? ceiling : floor);    
                }

                if (equalityNumber == 0)
                {
                    found = true;
                    return middle;
                }
                else if (equalityNumber > 0)
                {
                    ceiling = middle - 1;
                    middle = ceiling / 2;
                }
                else
                {
                    floor = middle + 1;
                    middle = floor + ((ceiling - floor) / 2);
                }
            }
            return 1;
        }
    }
}
