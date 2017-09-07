using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int randomNumber;
            for (int i = 0; i < 100; i++)
            {
                randomNumber = random.Next(0, 100);

                Console.WriteLine(randomNumber);
            }
            Console.ReadKey();
            
        }
    }
}
