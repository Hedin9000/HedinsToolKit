using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HedinsToolKit.Sorting
{
    public static class Sorting
    {
        #region Bubble Sorting

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void BubbleSort<TItem>(IList<TItem> list)
            where TItem : IComparable
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
                        var arrayItem = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = arrayItem;
                    }
                }
            }
        }

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void BubbleSort<TItem>(TItem[] list)
            where TItem : IComparable
        {
            BubbleSort(list, (x, y) => x.CompareTo(y));
        }

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void BubbleSort<TItem>(TItem[] list, Comparison<TItem> comparison)
        {
            if (list.Length <= 1)
                return;
            var a = list;
            for (var i = 0; i < a.Length; i++)
            {
                for (var j = a.Length - 1; j > i; j--)
                {

                    if (comparison(a[j - 1], a[j]) > 0)
                    {
                        var arrayItem = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = arrayItem;
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
        /// <param name="comparison"></param>
        public static void MergeSort<TItem>(TItem[] list)
        where TItem : IComparable
        {
            MergeSort(list,(x, y) => x.CompareTo(y));
        }

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void MergeSort<TItem>(List<TItem> list)
            where TItem : IComparable
        {
            MergeSort(list, (x, y) => x.CompareTo(y));
        }
        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void MergeSort<TItem>(TItem[] list, Comparison<TItem> comparison)
        {
            var length = list.Length;
            if (length <= 1)
                return;

            var leftSize = length / 2;
            var rightSize = length - leftSize;

            var leftArray  = new TItem[leftSize];
            var rightArray = new TItem[rightSize];
       
            Array.Copy(list, 0, leftArray, 0, leftSize);
            Array.Copy(list, leftSize, rightArray, 0, rightSize);

            MergeSort(leftArray, comparison);
            MergeSort(rightArray, comparison);
            Merge(list, leftArray, rightArray, comparison);

        }

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void MergeSort<TItem>(List<TItem> list, Comparison<TItem> comparison)
        {
            var length = list.Count;
            if (length <= 1)
                return;

            var leftSize = length / 2;
            var rightSize = length - leftSize;

            var leftArray = list.GetRange(0,leftSize);
             var rightArray = list.GetRange(leftSize,rightSize);

            MergeSort(leftArray, comparison);
            MergeSort(rightArray, comparison);
            Merge(list, leftArray, rightArray, comparison);

        }

        /// <summary>
        /// Merge left array and right array to destination list.
        /// </summary>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="items"></param>
        /// <param name="leftArray"></param>
        /// <param name="rightArray"></param>
        /// <param name="comparison"></param>
        private static void Merge<TItem>(IList<TItem> items, IReadOnlyList<TItem> leftArray, IReadOnlyList<TItem> rightArray,
            Comparison<TItem> comparison)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var targetIndex = 0;
            var remaining = leftArray.Count + rightArray.Count;

            while (remaining > 0)
            {
                if (leftIndex >= leftArray.Count)
                {
                    items[targetIndex] = rightArray[rightIndex++];
                }
                else if (rightIndex >= rightArray.Count)
                {
                    items[targetIndex] = leftArray[leftIndex++];
                }
                else if (comparison(leftArray[leftIndex], rightArray[rightIndex]) < 0)
                {
                    items[targetIndex] = leftArray[leftIndex++];
                }
                else
                {
                    items[targetIndex] = rightArray[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }

        #endregion

    }
}
