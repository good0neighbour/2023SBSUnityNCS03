using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Random tRandom = new Random(777);  //777을 씨앗으로 뿌림
            Random tRandom = new Random();  //알아서 임의의 씨앗을 뿌림

            int tDice = tRandom.Next();
            Console.WriteLine($"Dice is {tDice.ToString()}");

            tDice = tRandom.Next(1, 6 + 1); //[1, 6]
            Console.WriteLine($"Dice is {tDice.ToString()}");

            Console.ReadLine();
        }
    }
}
