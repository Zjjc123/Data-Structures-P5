using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleClass
{
    class Cats
    {
        // fields
        private readonly Gender _gender;

        // properties
        public Gender Gender { get { return _gender;  } }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; private set; }
        public int Lives { get; set; }
        
        public bool IsDead()
        {
            return Lives == 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
