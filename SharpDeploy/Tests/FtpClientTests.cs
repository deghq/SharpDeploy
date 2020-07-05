using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class FtpClientTests
    {
        [Test]
        public void TestMethod()
        {
            var c = new FtpClient("127.0.0.1", "test", "password");
            c.Upload("hello.txt");
        }
    }
}
