using System;

namespace SharpDeploy
{
    class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 6) {
                Console.WriteLine("Usage: sharpdeploy <dir> <commit1> <commit2> <host> <username> <password>");
                return;
            }
            
            string directory = args[0];
            
            string from = args[1];
            string to = args[2];
            
            string host = args[3];
            string username = args[4];
            string password = args[5];
            
            string remoteDirectory = "";
            if (args.Length == 7) {
                remoteDirectory = args[6];
            }
            
            try {
                
                var deployer = new Deployer(directory, host, username, password, remoteDirectory);
                deployer.Deploying += delegate(object sender, MessageEventArgs e) {
                    Console.WriteLine(e.Message);
                };
                deployer.Deploy(from, to);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}