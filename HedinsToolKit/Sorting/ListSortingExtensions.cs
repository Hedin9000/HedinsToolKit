using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.Sorting
{
    public static class ListSortingExtensions
    {
        /// <summary>
        /// Sort items by mode
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="mode">Sorting mode</param>
        public static void Sort<TItem>(this IList<TItem> list, SortingMode mode)
        where TItem : IComparable<TItem>
        {
            Sort(list, (x, y) => x.CompareTo(y), mode);
        }

        /// <summary>
        /// Sort items by mode
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        /// <param name="mode">Sorting mode</param>
        public static void Sort<TItem>(this IList<TItem> list, Comparison<TItem> comparison, SortingMode mode)
        {
            switch (mode)
            {
                case SortingMode.Bubble:
                    Sorting.BubbleSort(list, comparison);
                    break;
                case SortingMode.Merge:
                    Sorting.MergeSort(list, comparison);
                    break;
                case SortingMode.Quick:
                    Sorting.QuickSort(list, comparison);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        #region BubbleSort

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void BubbleSort<TItem>(this IList<TItem> list)
            where TItem : IComparable<TItem>
        {
            Sorting.BubbleSort(list);
        }

        /// <summary>
        /// Bubble Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void BubbleSort<TItem>(this IList<TItem> list, Comparison<TItem> comparison)
        {
            Sorting.BubbleSort(list,comparison);
        }

        #endregion

        #region MergeSort

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void MergeSort<TItem>(this IList<TItem> list)
            where TItem : IComparable<TItem>
        {
            Sorting.MergeSort(list);
        }

        /// <summary>
        /// Merge Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void MergeSort<TItem>(this IList<TItem> list, Comparison<TItem> comparison)
        {
            Sorting.MergeSort(list, comparison);
        }
        
        #endregion

        #region QuickSort

        /// <summary>
        /// Quick Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        public static void QuickSort<TItem>(this IList<TItem> list)
            where TItem : IComparable<TItem>
        {
            Sorting.QuickSort(list);
        }

        /// <summary>
        /// Quick Sorting algoritm
        /// </summary>
        /// <typeparam name="TItem">Type of item</typeparam>
        /// <param name="list">List of item</param>
        /// <param name="comparison">Comparison func. Example for list of int: (x, y) => x - y)</param>
        public static void QuickSort<TItem>(this IList<TItem> list, Comparison<TItem> comparison)
        {
            Sorting.QuickSort(list, comparison);
        }

        #endregion

    }
}
