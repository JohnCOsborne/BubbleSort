using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching.Model.Interfaces
{
    interface ISorter
    {
        void SortAlphabetically(ref IList<Person> collectionToSearch);
    }
}
