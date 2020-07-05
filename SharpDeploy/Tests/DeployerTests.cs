using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class DeployerTests
    {
        [Test]
        public void TestMethod()
        {
            string version = "";
            var d = new Deployer(version);
            string path = @"D:\xampp\htdocs\red\sugal";
            d.Deploy(path);
        }
    }
}
