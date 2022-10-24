using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestClasses
{
    public class ValList
    {
        public List<int> Numbers { get; set; }
        public ValList()
        {
            Numbers = new List<int>();
        }
    }
}
