using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Xml.Serialization;

namespace HedinsToolKit.Sorting
{
    public static class Sort
    {
        #region Bubble Sorting

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void BubbleSort<TItem>(IList<TItem> list)
            where TItem : IComparable<TItem>
        {
            BubbleSort(list, (x, y) => x.CompareTo(y));
        }

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void BubbleSort<TItem>(IList<TItem> list, Comparison<TItem> comparison)
        {
            if (list.Count <= 1)
                return;
            var a = list;
            for (var i = 0; i < a.Count; i++)
            {
                for (var j = a.Count - 1; j > i; j--)
                {
                    if (comparison(a[j - 1], a[j]) > 0)
                    {
                        Swap(list, j - 1, j);
                    }
                }
            }
        }

        #endregion

        #region Merge Sorting

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void MergeSort<TItem>(IList<TItem> list)
        where TItem : IComparable<TItem>
        {
            MergeSort(list,(x, y) => x.CompareTo(y));
        }

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void MergeSort<TItem>(IList<TItem> list, Comparison<TItem> comparison)
        {
            MergeSort(list,comparison,0,list.Count-1);
        }
        
        private static void MergeSort<TItem>(IList<TItem> list, Comparison<TItem> comparison, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var length = (rightIndex + leftIndex) / 2;

                MergeSort(list, comparison, leftIndex, length);

                length++;

                MergeSort(list, comparison, length, rightIndex);

                Merge(list, comparison, leftIndex, length, rightIndex);
            }
        }

        private static void Merge<TItem>(IList<TItem> list, Comparison<TItem> comparison, int leftIndex, int midIndex, int rightIndex)
        {
            var tempItems = new TItem[list.Count];
        
            var leftEnd = midIndex - 1;
            var tempPosition = leftIndex;
            var lengthOfInput = rightIndex - leftIndex + 1;

            while ((leftIndex <= leftEnd) && (midIndex <= rightIndex))
            {
                if (comparison(list[leftIndex], list[midIndex]) <= 0)
                {
                    tempItems[tempPosition++] = list[leftIndex++];
                }
                else
                {
                    tempItems[tempPosition++] = list[midIndex++];
                }
            }

            while (leftIndex <= leftEnd)
            {
                tempItems[tempPosition++] = list[leftIndex++];
            }

            while (midIndex <= rightIndex)
            {
                tempItems[tempPosition++] = list[midIndex++];
            }

            for (var i = 0; i < lengthOfInput; i++) 
            {
                list[rightIndex] = tempItems[rightIndex];
                rightIndex--;
            }
        }

        #endregion

        #region QuickSort

        /// <summary>
        /// Quick Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void QuickSort<TItem>(IList<TItem> list)
        where TItem : IComparable<TItem>
        {
            QuickSort(list, ((x, y) => x.CompareTo(y)));
        }

        /// <summary>
        /// Quick Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void QuickSort<TItem>(IList<TItem> list, Comparison<TItem> comparison)
        {
            QuickSort(list,comparison,0,list.Count -1);
        }

        private static void QuickSort<TItem>(IList<TItem> items, Comparison<TItem> comparison, int startIndex, int endIndex)
        {
            var leftIndex = startIndex;
            var rightIndex = endIndex;
            var pivot = items[(startIndex + endIndex) / 2];

            while (leftIndex <= rightIndex)
            {
                while (comparison(items[leftIndex],pivot) < 0)
                {
                    leftIndex++;
                }

                while (comparison(items[rightIndex],pivot) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    Swap(items, leftIndex,rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }
   
            if (startIndex < rightIndex)
            {
                QuickSort(items, comparison, startIndex, rightIndex);
            }

            if (leftIndex < endIndex)
            {
                QuickSort(items, comparison, leftIndex, endIndex);
            }
        }
        
        #endregion

        #region Helpers

        /// <summary>
        /// Swap two items in list.
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="items">List of items</param>
        /// <param name="sourseIndex">First index</param>
        /// <param name="destinationIndex">Second index</param>
        public static void Swap<TItem>(IList<TItem> items, int sourseIndex, int destinationIndex)
        {
            if (sourseIndex != destinationIndex)
            {
                var temp = items[sourseIndex];
                items[sourseIndex] = items[destinationIndex];
                items[destinationIndex] = temp;
            }
        }

        #endregion
    }
}
