using System;

namespace SharpDeploy
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 4) {
                Console.WriteLine("Usage: sharpdeploy . 127.0.0.1 test password");
                return;
            }
            
            string _from = ""; // TODO:
            string to = ""; // TODO:
            
            string directory = args[0];
            
            string host = args[1];
            string username = args[2];
            string password = args[3];
            
            try {
                
                var deployer = new Deployer(directory, host, username, password);
                deployer.Deploying += delegate(object sender, MessageEventArgs e) {
                    Console.WriteLine(e.Message);
                };
                deployer.Deploy(_from, to);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}