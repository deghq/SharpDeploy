using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class DeployerTests
    {
        [Test]
        public void TestDeploy()
        {
            string path = @"D:\Contrib\SharpDeploy";
            string host = "127.0.0.1";
            string username = "test";
            string password = "password";
            
            var d = new Deployer(path, host, username, password);
            
            string version = "736b6b086babd446d3df082913a075096875c5f2";
            d.Deploying += delegate(object sender, MessageEventArgs e) { 
                Console.WriteLine(e.Message);
            };
            d.Deploy(version, "");
        }
    }
}
