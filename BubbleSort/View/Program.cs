using SortingAndSearching;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {

            ListProvider listProvider = new ListProvider("C:\\Users\\JCBoss\\Downloads\\BubbleSort\\BubbleSort\\names.txt");
            listProvider.SortWithBubbleSortAlphabetically();

            foreach (Person person in listProvider.TheList)
            {
                Console.WriteLine(person.FirstName + " at: " + listProvider.TheList.IndexOf(person));
            }

            Console.WriteLine("Would you like to search for a name? Enter yes or no.");

            string result = Console.ReadLine();
            if (result == "yes")
            {
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();
                int index = listProvider.BinarySearch(name);
                if (index == -1)
                {
                    Console.WriteLine("The name was not found");
                    return;
                }
                Console.WriteLine("You searched for {0} at index {1}", listProvider.TheList[index].FirstName, index);
            }
        }
    }
}
