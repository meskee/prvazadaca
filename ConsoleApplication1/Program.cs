using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[]args)
        {
            IntegerList listOfIntegers = new IntegerList();
            listOfIntegers.init();
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);

            listOfIntegers.RemoveAt(0);
            listOfIntegers.Remove(5);
            Console.WriteLine(listOfIntegers.Count);
            Console.ReadLine();
            Console.WriteLine(listOfIntegers.Remove(100));
            Console.ReadLine();
            Console.WriteLine(listOfIntegers.RemoveAt(5));
            Console.ReadLine();
            listOfIntegers.Clear();
            Console.WriteLine(listOfIntegers.Count);
            Console.ReadLine();
        }
    }
}
