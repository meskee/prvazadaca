using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<String> List = new GenericList<string>();
            List.Add("Hello");
            List.Add("World");
            List.Add("!");

            foreach(string word in List)
            {
                Console.WriteLine(word);
                Console.ReadLine();
            }
        }
    }
}
