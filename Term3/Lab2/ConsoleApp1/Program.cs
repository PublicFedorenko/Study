using DynamicArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> da = new DynamicArray<int>();

            Console.WriteLine("Add few items to dynamic array:");
            for (int i = 0; i < 15; i++)
            {
                da[i] = i;
                Console.Write(da[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Remove item 0");
            da.Remove(0);
            Show(da);
            Console.WriteLine();

            Console.WriteLine("Remove item 4");
            da.Remove(4);
            Show(da);
            Console.WriteLine();

            Console.WriteLine("Remove item 5");
            da.Remove(5);
            Show(da);
            Console.WriteLine();
        }

        public static void Show(DynamicArray<int> da)
        {
            for (int i = 0; i < da.Size; i++)
            {
                Console.Write(da[i] + " ");
            }
        }
    }
}
