using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToString();

            if (str.Length != 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(str);
                }
                Console.Read();
            }
        }
    }
}
