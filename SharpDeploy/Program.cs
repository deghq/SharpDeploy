using System;

namespace SharpDeploy
{
    class Program
    {
        public static void Main(string[] args)
        {
            string version = "";
            new Deployer(version).Deploy(Environment.CurrentDirectory);
            
//            Console.WriteLine("Hello World!");
//            
//            Console.Write("Press any key to continue . . . ");
//            Console.ReadKey(true);
        }
    }
}