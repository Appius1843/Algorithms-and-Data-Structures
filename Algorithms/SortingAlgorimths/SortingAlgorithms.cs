﻿#region

using System;
using System.Linq;

#endregion

namespace SortingAlgorimths
{
    /// <summary>
    ///     Алгоритмы сортировки
    /// </summary>
    /// <typeparam name="T">Тип данных, коллекцию объектов которых надо отсортировать</typeparam>
    public static class SortingAlgorithms<T> where T : IComparable
    {
        /// <summary>
        ///     Сортировка пузырем
        /// </summary>
        /// <param name="array">Массив данных</param>
        public static T[] BubbleSort(params T[] array)
        {
            for (int n = array.Length - 1; n >= 0; n--)
            {
                var isSwaped = false;
                for (int i = 0; i < n; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        isSwaped = true;
                    }
                }
                if (!isSwaped) break;
            }
            return array;
        }

        /// <summary>
        ///     Сортировка вставками
        /// </summary>
        /// <param name="array">Коллекция данных</param>
        public static T[] InsertionSort(params T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    var temp = array[i];
                    var j = i - 1;
                    while (j >= 0 && array[j].CompareTo(temp) > 0)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        /// <summary>
        ///     Сортировка выборкой
        /// </summary>
        /// <param name="array">Коллекция данных</param>
        public static T[] SelectionSort(params T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T min = array[i];
                int index = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(min) < 0)
                    {
                        min = array[j];
                        index = j;
                    }
                }
                int k = index - 1;
                while (k >= i)
                {
                    array[k + 1] = array[k];
                    k--;
                }
                array[k + 1] = min;
            }
            return array;
        }

        /// <summary>
        ///     Сортировка слиянием
        /// </summary>
        /// <param name="array">Массив данных</param>
        public static T[] MergeSort(params T[] array)
        {
            if (array.Length > 1)
            {
                int n = array.Length/2;
                T[] lt = array.Take(n).ToArray();
                T[] rt = array.Skip(n).Take(array.Length - n).ToArray();

                lt = MergeSort(lt);
                rt = MergeSort(rt);

                var newArray = new T[array.Length];
                var i = 0;
                var j = 0;
                var index = 0;

                while (i + j < array.Length)
                {
                    if (i == lt.Length || (j != rt.Length && lt[i].CompareTo(rt[j]) > 0))
                    {
                        newArray[index] = rt[j];
                        j++;
                    }
                    else
                    {
                        newArray[index] = lt[i];
                        i++;
                    }
                    index++;
                }
                return newArray;
            }
            return array;
        }

        /// <summary>
        /// Быстрая сотрировка
        /// </summary>
        /// <param name="array">Массив данных</param>
        /// <param name="l">Индекс первого элемента массива (можно не указывать, если сортировать сначала массива)</param>
        /// <param name="r">Инлекс последнего элемента массива (можно не указывать, если сортировать массив до последнего элемента)</param>
        public static T[] QuickSort(T[] array, int l = -1, int r = -1)
        {
            if (l == -1 && r == -1)
            {
                l = 0;
                r = array.Length - 1;
            }
            T x = array[(l + r) / 2];
            
            int i = l;
            int j = r;
            
            while (i <= j)
            {
                while (array[i].CompareTo(x) < 0) i++;
                while (array[j].CompareTo(x) > 0) j--;
                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (i < r) array = QuickSort(array, i, r);
            if (l < j) array = QuickSort(array, l, j);
            return array;
        }
    }
}