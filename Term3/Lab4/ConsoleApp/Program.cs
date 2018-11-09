using Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private delegate bool CompareSymbols(string str);

        static void Main(string[] args)
        {
            #region FirstTask
            /* Lambda Expr */
            CompareSymbols compareSymbolsLambda = 
                str =>
                {
                    int lettersCount = Regex.Matches(str, @"\w").Count;
                    int digitsCount = Regex.Matches(str, @"\d").Count;
                    return lettersCount > digitsCount;
                };

            /* Anonymous method */
            CompareSymbols compareSymbolsAnonymous =
                delegate (string str)
                {
                    int lettersCount = Regex.Matches(str, @"\w").Count;
                    int digitsCount = Regex.Matches(str, @"\d").Count;
                    return lettersCount > digitsCount;
                };
            #endregion

            #region SecondTask
            CustomList<int> customList = new CustomList<int>();
            customList.OnItemAdded += (sender, e) => Console.WriteLine($"{e.Message} Length: {e.Length}");
            customList.OnItemInserted += (sender, e) => Console.WriteLine($"{e.Message} Length: {e.Length}");
            customList.OnItemRemoved += (sender, e) => Console.WriteLine($"{e.Message} Length: {e.Length}");
            customList.OnListCleared += (sender, e) => Console.WriteLine($"{e.Message} Length: {e.Length}");
            Menu.Show(customList);
            #endregion
        }
    }
}
