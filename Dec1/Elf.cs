using System;

namespace Dec1
{
    public class Elf : IComparable
    {
        public int Calories { get; set; }

        public Elf()
        {
            Calories = 0;
        }

        public int CompareTo(object obj)
        {
            Elf other = obj as Elf;
            if (other.Calories == Calories)
            {
                return 0;
            }

            if (other.Calories > Calories)
            {
                return -1;
            }

            return 1;
        }
    }
}