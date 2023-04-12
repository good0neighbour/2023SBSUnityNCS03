using System;

namespace cs_Random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Random은 System 네임스페이스 안에 포함되어 있다.
            //Random tRandom = new Random(777);  //777을 씨앗으로 뿌림
            Random tRandom = new Random();  //알아서 임의의 씨앗을 뿌림

            int tDice = tRandom.Next();
            Console.WriteLine($"Dice is {tDice.ToString()}");

            for (int ti = 0; ti < 20; ++ti)
            {
                tDice = tRandom.Next(1, 6 + 1); //[1, 6]
                Console.WriteLine($"Dice is {tDice.ToString()}");
            }

            Console.ReadLine();
        }
    }
}
