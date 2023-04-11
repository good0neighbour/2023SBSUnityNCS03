using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_first
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cs_first");

            int tA = 777;
            Console.WriteLine("I am a Good Boy. This is {0}", tA);

            float tB = 3.14159f;
            Console.WriteLine("I am a Good Boy. This is {0:F2}", tB);   //F뒤에 붙은 숫자는 소수점 이하 몇 자리까지라는 의미

            string tString = "string test";
            Console.WriteLine("STRING is " + tString);

            //개행
            Console.WriteLine();

            //보간 문자열
            //보간 문자열 만드는 방법. $표시를 앞에 붙인다.
            string tRyuString = $"We are The Good Boys. This is {tA}, PI is {tB}, STRING is {tString}";
            Console.WriteLine(tRyuString);


            Console.ReadLine();
        }
    }
}
