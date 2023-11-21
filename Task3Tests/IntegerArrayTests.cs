using System;
using System.Collections.Generic;
using Task3;
using Xunit;

namespace Task3Tests
{
    public class IntegerArrayTests
    {
        [Fact]
        public void TestInputDataRandom()
        {
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            
            Assert.NotEmpty(arr.ToArray());
        }

        [Fact]
        public void TestPrint()
        {
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            
            Assert.Throws<IndexOutOfRangeException>(() => arr.Print(0, 6));
        }

        [Fact]
        public void TestFindValue()
        {
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            var indexes = arr.FindValue(arr.GetElement(arr.Length - 1));
            Assert.Contains(arr.Length - 1, indexes);
        }

        [Fact]
        public void TestDeleteValue()
        {
            int valueToDelete = 10;
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            arr.DeleteValue(valueToDelete);
            Assert.DoesNotContain(valueToDelete, arr.ToArray());
        }

        [Fact]
        public void TestFindMax()
        {
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            int max = arr.FindMax();
            Assert.True(max >= arr.GetElement(0));
        }

        [Fact]
        public void TestAdd()
        {
            IntegerArray arr1 = new IntegerArray(3);
            arr1.InputDataRandom();
        
            IntegerArray arr2 = new IntegerArray(3);
            arr2.InputDataRandom();

            IntegerArray result;
            arr1.Add(arr2, out result);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(result.GetElement(i), arr1.GetElement(i) + arr2.GetElement(i));
            }
        }

        [Fact]
        public void TestSort()
        {
            IntegerArray arr = new IntegerArray(5);
            arr.InputDataRandom();
            arr.Sort();

            for (int i = 1; i < arr.Length; i++)
            {
                Assert.True(arr.GetElement(i - 1) <= arr.GetElement(i));
            }
        }
    }
}