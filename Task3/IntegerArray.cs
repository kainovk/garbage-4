using System;
using System.Collections.Generic;

namespace Task3
{
    public class IntegerArray
    {
        private int[] array;

        public IntegerArray(int size)
        {
            array = new int[size];
        }

        public int Length => array.Length;

        public void InputDataRandom()
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }
        }

        public void Print(int startIndex, int endIndex)
        {
            if (startIndex < 0 || startIndex >= array.Length || endIndex < 0 || endIndex >= array.Length)
            {
                throw new IndexOutOfRangeException(
                    $"Indexes {startIndex} or {endIndex} is out of range for array with length={Length}"
                );
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
        }

        public List<int> FindValue(int value)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        public void DeleteValue(int value)
        {
            int newSize = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != value)
                {
                    array[newSize] = array[i];
                    newSize++;
                }
            }

            Array.Resize(ref array, newSize);
        }

        public int FindMax()
        {
            int max = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public void Add(in IntegerArray otherArray, out IntegerArray result)
        {
            if (array.Length != otherArray.array.Length)
            {
                throw new ArgumentException("Arrays must have the same length for addition.");
            }

            result = new IntegerArray(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                result.array[i] = array[i] + otherArray.array[i];
            }
        }

        public void Sort()
        {
            Array.Sort(array);
        }

        public int GetElement(int index)
        {
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return array[index];
        }

        public int[] ToArray()
        {
            return array;
        }
    }
}