using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleClass
{
    public enum Gender
    {
        male, female
    }
    class Dog
    {
        private string _name;
        private int _age;
        private int _weight;
        private readonly Gender _gender;

        public string Name
        {
            get { return this._name;  }
            set { this._name = value; }
        }

        public int Age
        {
            get { return this._age; }
            set { this._age = value; }
        }
    }
}
