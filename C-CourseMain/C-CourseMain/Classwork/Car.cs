using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace C_CourseMain
{
    class Car
    {
        private Owner owner;
        public Car()
        {
            AllOwners = new List<Owner>();
        }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public double StickerPrice { get; set; }

        public Owner Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                AllOwners.Add(value);
            }
        }

        public List<Owner> AllOwners { get; set; }
    }

    class Owner : IComparable
    {
        public string Name { get; set; }
        public string Country { get; set; }

        public int CompareTo(object obj)
        {
            return Name.Length - ((Owner)obj).Name.Length;
        }
    }

    class QueriableDemo : IQueryable
    {
        public Expression Expression => throw new NotImplementedException();

        public Type ElementType => throw new NotImplementedException();

        public IQueryProvider Provider => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
