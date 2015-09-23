using System;
using System.Numerics;

namespace _06_.BitArray
{
    class BitArray
    {
        byte[] array;
        BigInteger number;

        public BitArray(int numberOfBits)
        {
            array = new byte[numberOfBits];
        }

        public int Length 
        {
            get
            {
                return this.array.Length;
            }
        }

        public int this [int index]
        {
            get 
            {
                if (index >= 0 && (index < this.array.Length || index < 100000))
                {
                    return this.array[index];
                }
                else throw new IndexOutOfRangeException("Invalid index.");
            }
            set
            {
                if (index >= 0 && index < this.array.Length)
                {
                    this.array[index] = (byte)value;
                }
                else throw new IndexOutOfRangeException("Invalid index.");
            }
        }

        public override string ToString()
        {
            number = new BigInteger();
            for (int ind = 0; ind < array.Length; ind++)
            {
                number |= ((BigInteger)array[ind] << ind);
            }
            return number.ToString();
        }
    }
}
