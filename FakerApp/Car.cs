using System;
using System.Collections.Generic;
using System.Text;

namespace FakerApp
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public User user { get; set; }
        public Car()
        {
            Id = 228;
        }
    }
}
