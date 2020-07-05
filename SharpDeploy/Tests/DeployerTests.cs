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
            
            d.Deploying += delegate(object sender, MessageEventArgs e) { 
                Console.WriteLine(e.Message);
            };
            d.Deploy("", "");
        }
    }
}
