using System;

namespace Lab01C_SophiaSiguere_1057719
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            parser.Parse(regexp);
            Console.WriteLine("Expresion OK");
            Console.ReadLine();

        }
    }
}
