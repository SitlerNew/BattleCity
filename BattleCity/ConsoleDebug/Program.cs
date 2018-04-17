using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleDebug
{
    public class MyDebugg
    {
        public static void Print(int x)
        {
            Console.WriteLine(x);
        }

        public static void Print(char x)
        {
            Console.WriteLine(x);
        }

        public static void Print(string x)
        {
            Console.WriteLine(x);
        }

        public static void Print(float x)
        {
            Console.WriteLine(x);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MyDebugg a = new MyDebugg();
        }
    }
}
