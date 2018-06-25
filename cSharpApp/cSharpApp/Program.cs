using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpApp
{
    class Program
    {
        /*Enumeration*/
        enum Days {Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        static void Main(string[] args)
        {
            string str = Console.ReadLine().ToString();

            if (str.Length != 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(str);
                }
       
            }
            /*Enumeration cont.*/
            Console.WriteLine(Days.Sunday);

            /*Variables */
            Int32 val1 = 10, val2 = 20;
            bool status = true;

            Console.WriteLine(val1 + val2);

            Console.WriteLine(val1 < val2);

            Console.WriteLine(!(status));

            /*Switch Statements*/
            switch (val2)
            {
                case 1: Console.WriteLine("Value is 1");
                    break;
                case 2: Console.WriteLine("Value is 2");
                    break;
                default: Console.WriteLine("Value is different");
                    break;
            }

            /*Arrays*/

            Int32[] values;
            values = new Int32[3];

            values[0] = 1;
            values[1] = 2;
            values[2] = 3;
            
            /*Iterating Array using For Loop*/
            for (Int32 i = 0; i < values.Length; i++) {
                Console.WriteLine(values[i]);
            }
            Console.Read();
        }
    }
}
