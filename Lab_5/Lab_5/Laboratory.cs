using System;

namespace Lab5_OOP
{
    public class Laboratory
    {
        private Scientist[] staff;
        
        public Laboratory(int size)
        {
            staff = new Scientist[size];
        }

        public Scientist this[int index]
        {
            get
            {
                if (index >= 0 && index < staff.Length) return staff[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < staff.Length) staff[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public int Length => staff.Length;
    }
}