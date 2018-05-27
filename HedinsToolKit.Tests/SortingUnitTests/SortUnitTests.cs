using System;
using System.Collections.Generic;
using Xunit;
using HedinsToolKit.Sorting;
using System.Linq;

namespace HedinsToolKit.Tests
{
    public class SortUnitTest
    {
        [Fact]
        public void BubbleSortTest()
        {
            var list = CreateRandomList(1000,0,100);
            Sort.BubbleSort(list,(x,y)=> x.CompareTo(y));
            CheckSort(list, (x,y)=>x.CompareTo(y));            
        }

        [Fact]
        public void MergeSortTest()
        {
            var list = CreateRandomList(1000,0,100);
            Sort.MergeSort(list,(x,y)=> x.CompareTo(y));
            CheckSort(list, (x,y)=>x.CompareTo(y));            
        }        

        [Fact]
        public void QuickSortTest()
        {
            var list = CreateRandomList(1000,0,100);
            Sort.QuickSort(list,(x,y)=> x.CompareTo(y));
            CheckSort(list, (x,y)=>x.CompareTo(y));            
        }

        private List<int> CreateRandomList(int countRandomElements, int minValue, int maxValue)
        {
            var list = new List<int>();
            var random = new Random();
            for (int i = 0; i < countRandomElements; i++)
            {
                list.Add(random.Next(minValue,maxValue));
            }
            return list;
        }
        private void CheckSort<TItem>(IList<TItem> list, Comparison<TItem> comparison)
        {            
            for (var i = 1; i < list.Count; i++)
            {
                Assert.True(comparison(list[i], list[i-1]) >=0);
            }
        }
    }
}
