using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class Person : IComparable
    {
        private string p1;
        private string p2;

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
