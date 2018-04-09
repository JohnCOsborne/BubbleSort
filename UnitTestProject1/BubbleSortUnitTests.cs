using BubbleSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAndSearching;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BubbleSortUnitTests
    {
        //Fields
        private string[] namesOne;
        private string[] namesTwoSorted; 
        private string[] namesThree;
        private string[] namesFour;
        private string[] namesFive;
        private string[] namesSix;
        private string[] namesSeven;

        private ListProvider providerOne;
        private ListProvider providerTwo;
        private ListProvider providerThree;
        private ListProvider providerFour;
        private ListProvider providerFive;
        private ListProvider providerSix;
        private ListProvider providerSeven;

        private string[] namesOneSorted;
        private string[] namesThreeSorted;
        private string[] namesFiveSorted;
        private string[] namesSixSorted;

        [TestInitialize]
        public void Setup()
        {
            //Bubble Sort test cases
            //Boundary/unique cases(excluding 0): 1,2,3,odd and even, already sorted
            namesOne = new string[] {"Bob","Greg","Ava", "Josie"}; //Even amount
            namesOneSorted = new string[] { "Ava", "Bob", "Greg", "Josie" };
            namesTwoSorted = new string[] {"Ava","John","Melissa", "Todd" };//already sorted
            namesThree = new string[] { "Stephanie", "Jessica", "Rachel", "Robert", "Florence", "Tito","Alexander" }; //odd
            namesThreeSorted = new string[] { "Alexander", "Florence", "Jessica", "Rachel", "Robert", "Stephanie", "Tito" };
            namesFour = new string[] { "Alexander", "Florence", "Jessica", "Rachel", "Robert", "Stephanie", "Tito","Fanny","John","Melissa","Gregory","Michael","Gabriel","William","Timothy","Boxmus","Frantitudal","Jose","Jeremy","Thurman","Chandler","Tina","Andy","Jim","Pam","Roger"};//Large even
            namesFive = new string[] { "Fitz","Donald","Zed" };
            namesFiveSorted = new string[] { "Donald", "Fitz","Zed" };
            namesSix = new string[] {"Randy" };
            namesSixSorted = new string[] { "Randy"};
            namesSeven = new string[] { "Alexander", "Florence", "Jessica", "Rachel", "Robert", "Stephanie", "Tito", "Fanny", "John", "Melissa", "Gregory", "Michael", "Gabriel", "William", "Timothy", "Boxmus", "Frantitudal", "Jose", "Jeremy", "Thurman", "Chandler", "Tina", "Andy", "Jim", "Pam" };//Large odd


            providerOne = new ListProvider();
            providerTwo = new ListProvider();
            providerThree = new ListProvider();
            providerFour = new ListProvider();//For binary search
            providerFive = new ListProvider();
            providerSix = new ListProvider();
            providerSeven = new ListProvider();//For binary search

            LoadList(namesOne, providerOne);
            LoadList(namesTwoSorted, providerTwo);
            LoadList(namesThree, providerThree);
            LoadList(namesFour, providerFour);
            LoadList(namesFive, providerFive);
            LoadList(namesSix, providerSix);
            LoadList(namesSeven, providerSeven);
        }

        private void LoadList(string[] nameList, ListProvider provider){
            List<Person> personList = new List<Person>();
            foreach (string item in nameList)
            {
                personList.Add(new Person(item, "N/A"));
            }

            provider.TheList = personList;
        }

        #region BubbleSort tests

        [TestMethod]
        [TestCategory("Bubble")]
        public void TestProviderOne()
        {
            Setup();
            providerOne.SortWithBubbleSortAlphabetically();
            string[] actualNames = providerOne.TheList.Select(x=>x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(actualNames,namesOneSorted);
        }

        [TestMethod]
        [TestCategory("Bubble")]
        public void TestProviderTwo()
        {
            Setup();
            providerTwo.SortWithBubbleSortAlphabetically();
            string[] actualNames = providerTwo.TheList.Select(x => x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(actualNames, namesTwoSorted);
        }

        [TestMethod]
        [TestCategory("Bubble")]
        public void TestProviderThree()
        {
            Setup();
            providerThree.SortWithBubbleSortAlphabetically();
            string[] actualNames = providerThree.TheList.Select(x => x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(namesThreeSorted,actualNames);
        }

        [TestMethod]
        [TestCategory("Bubble")]
        public void TestThreeElements()
        {
            Setup();
            providerFive.SortWithBubbleSortAlphabetically();
            string[] actualNames = providerFive.TheList.Select(x => x.FirstName).ToArray();
            CollectionAssert.AreEqual(namesFiveSorted, actualNames);
        }

        [TestMethod]
        [TestCategory("Bubble")]
        public void TestOneElement()
        {
            Setup();
            providerSix.SortWithBubbleSortAlphabetically();
            string[] actualNames = providerSix.TheList.Select(x => x.FirstName).ToArray();
            CollectionAssert.AreEqual(namesSixSorted, actualNames);
        }
        #endregion
        #region BinarySearch Tests

        //These are the Binary Search tests
        //Boundary cases: 1 element, 2 elements, No match, duplicate names?, 
        //Other cases: Odd amount, Even amount, Large amount

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void TestBinarySearchLargeEven()
        {
            Setup();
            providerFour.SortWithBubbleSortAlphabetically();

            Dictionary<string, int> indexMap = new Dictionary<string, int>();

            foreach (Person item in providerFour.TheList)
            {
                indexMap.Add(item.FirstName, providerFour.TheList.IndexOf(item));
            }

            foreach (Person name in providerFour.TheList)
            {
                Assert.AreEqual(indexMap[name.FirstName], providerFour.BinarySearch(name.FirstName));
            }
        }

        [TestMethod]
        [TestCategory("BinarySearch")]
        public void TestBinarySearchLargeOdd()
        {
            Setup();
            providerSeven.SortWithBubbleSortAlphabetically();

            Dictionary<string, int> indexMap = new Dictionary<string, int>();
            foreach(Person item in providerSeven.TheList)
            {
                indexMap.Add(item.FirstName, providerSeven.TheList.IndexOf(item));
            }

            foreach(Person name in providerSeven.TheList)
            {
                Assert.AreEqual(indexMap[name.FirstName], providerSeven.BinarySearch(name.FirstName));
            }
        }

        #endregion

    }
}
