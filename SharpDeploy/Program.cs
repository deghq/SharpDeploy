using System;

namespace SharpDeploy
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Deployer(Environment.CurrentDirectory).Deploy();
            
//            Console.WriteLine("Hello World!");
//            
//            Console.Write("Press any key to continue . . . ");
//            Console.ReadKey(true);
        }
    }
}