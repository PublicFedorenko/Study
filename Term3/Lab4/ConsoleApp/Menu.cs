using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Menu
    {
        public static void ShowChoices()
        {
            Console.WriteLine("1. Add item.");
            Console.WriteLine("2. Insert item.");
            Console.WriteLine("3. Remove item.");
            Console.WriteLine("4. Clear list.");
        }

        public static void Show(CustomList<int> list)
        {
            ShowChoices();
            ConsoleKey input = Console.ReadKey().Key;
            while (input != ConsoleKey.Q)
            {
                switch (input) {
                    case ConsoleKey.D1:
                        {
                            Console.Write("\nEnter number: ");
                            int.TryParse(Console.ReadLine(), out int item);
                            list.Add(item);
                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            Console.Write("\nEnter index: ");
                            int.TryParse(Console.ReadLine(), out int index);
                            Console.Write("\nEnter number: ");
                            int.TryParse(Console.ReadLine(), out int item);
                            list.Insert(index, item);
                        }
                        break;
                    case ConsoleKey.D3:
                        {
                            Console.Write("\nEnter index: ");
                            int.TryParse(Console.ReadLine(), out int index);
                            list.Remove(index);
                        }
                        break;
                    case ConsoleKey.D4:
                        {
                            Console.WriteLine();
                            list.Clear();
                        }
                        break;
                    case ConsoleKey.H:
                        {
                            Console.Clear();
                            ShowChoices();
                        }
                        break;
                }
                input = Console.ReadKey().Key;

            }
        }
    }
}
