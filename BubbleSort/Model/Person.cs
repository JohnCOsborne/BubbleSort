using System;

namespace SortingAndSearching
{
    public class Person : IComparable
    {
        public String FirstName { get; set; }
        public String LastName {get; set;}
        public String PhoneNumber { get; set; }
        public Person(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        //TODO: Implement Custom Comparison
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
          //  Person personToBeCompared = (Person)obj;

         //   return String.Compare(this.FirstName,)
            return -1;
        }

    }
}
