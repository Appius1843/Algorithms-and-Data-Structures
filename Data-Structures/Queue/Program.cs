﻿#region

using System;

#endregion

namespace Queue
{
    internal class Program
    {
        private static void Main()
        {
            var queue = new Queue<int>();

            queue.Push(3);
            queue.Push(5);
            queue.Push(7);
            Console.WriteLine(queue);
            Console.WriteLine(queue.Count);

            queue.Pop();
            Console.WriteLine(queue);

            queue.Pop();
            queue.Peek();
            Console.WriteLine(queue);

            Console.ReadKey();
        }
    }
}