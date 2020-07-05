using System;
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
        }
        
        [Test]
        public void TestUpload()
        {
            c.Upload("hello.txt", "hello.txt");
        }
        
        [Test]
        public void TestCreateDirectory()
        {
            c.CreateDirectory("test");
        }
    }
}
