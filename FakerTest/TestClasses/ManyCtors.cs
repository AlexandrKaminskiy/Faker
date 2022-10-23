using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.TestClasses
{
    public class ManyCtors
    {
        public bool Value { get; set; } = false;
        public ManyCtors()
        {
            Value = true;
        }
        public ManyCtors(bool value)
        {
            this.Value = value;
        }
    }
}
