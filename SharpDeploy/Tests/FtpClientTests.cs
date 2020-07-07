using System;
using System.IO;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class FtpClientTests
    {
        FtpClient c;
        
        [SetUpAttribute]
        public void Setup()
        {
            c = new FtpClient("127.0.0.1", "test", "password");
            c.Uploading += delegate(object sender, MessageEventArgs e) { 
                Console.WriteLine(e.Message);
            };
        }
        
        [Test]
        public void TestUpload()
        {
            c.Upload(@"D:\Contrib\SharpDeploy\SharpDeploy\Program.cs", "test\\test2\\Program.cs");
        }
        
        [Test]
        public void TestCreateDirectory()
        {
            c.CreateDirectory("test\\test2");
        }
    }
}
