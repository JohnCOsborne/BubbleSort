using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using BubbleSort;
using System.Linq;

namespace BubbleSortTests
{
    [TestClass]
    public class BubbleSortUnitTests
    {
        //Fields
        private string[] namesOne;
        private string[] namesTwoSorted; 
        private string[] namesThree;
        private string[] namesFour;

        private ListProvider providerOne;
        private ListProvider providerTwo;
        private ListProvider providerThree;
        private ListProvider providerFour;
        private string[] namesOneSorted;
        private string[] namesThreeSorted;

        public void Setup()
        {
            namesOne = new string[] {"Bob","Greg","Ava", "Josie"};
            namesOneSorted = new string[] { "Ava", "Bob", "Greg", "Josie" };
            namesTwoSorted = new string[] {"Ava","John","Melissa", "Todd" };
            namesThree = new string[] { "Stephanie", "Jessica", "Rachel", "Robert", "Florence", "Tito","Alexander" };
            namesThreeSorted = new string[] { "Alexander", "Florence", "Jessica", "Rachel", "Robert", "Stephanie", "Tito" };
            namesFour = new string[] { "Alexander", "Florence", "Jessica", "Rachel", "Robert", "Stephanie", "Tito","Fanny","John","Melissa","Gregory","Michael","Gabriel","William","Timothy","Boxmus","Frantitudal","Jose","Jeremy","Thurman","Chandler","Tina","Andy","Jim","Pam","Roger"};
            
            providerOne = new ListProvider();
            providerTwo = new ListProvider();
            providerThree = new ListProvider();
            providerFour = new ListProvider();

            LoadList(namesOne, providerOne);
            LoadList(namesTwoSorted, providerTwo);
            LoadList(namesThree, providerThree);
            LoadList(namesFour, providerFour);
        }

        private void LoadList(string[] nameList, ListProvider provider){
            List<Person> personList = new List<Person>();
            foreach (string item in nameList)
            {
                personList.Add(new Person(item, "N/A"));
            }

            provider.TheList = personList;
        }

        [TestMethod]
        public void TestProviderOne()
        {
            Setup();
            providerOne.sortWithBubbleSortAlphabetically();
            string[] actualNames = providerOne.TheList.Select(x=>x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(actualNames,namesOneSorted);
        }

        [TestMethod]
        public void TestProviderTwo()
        {
            Setup();
            providerTwo.sortWithBubbleSortAlphabetically();
            string[] actualNames = providerTwo.TheList.Select(x => x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(actualNames, namesTwoSorted);
        }

        [TestMethod]
        public void TestProviderThree()
        {
            Setup();
            providerThree.sortWithBubbleSortAlphabetically();
            string[] actualNames = providerThree.TheList.Select(x => x.FirstName).ToArray<string>();
            CollectionAssert.AreEqual(actualNames, namesThreeSorted);
        }

        #region SearchTests
        [TestMethod]
        public void TestBinarySearch()
        {
            Setup();
            providerFour.sortWithBubbleSortAlphabetically();

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

        #endregion

    }
}
