using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> List = new GenericList<string>();
            List.Add("Napravio");
            List.Add("sam");
            List.Add("prvu");
            List.Add("zadacu");
            List.RemoveAt(0);
            List.Remove("sam");
            Console.WriteLine(List.Count);
            Console.ReadLine();
        }
    }
}
