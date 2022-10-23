using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestClasses
{
    public class ClassWithValueList
    {
        public List<int> Numbers { get; set; }
        public ClassWithValueList()
        {
            Numbers = new List<int>();
        }
    }
}
