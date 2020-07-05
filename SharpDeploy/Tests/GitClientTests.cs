using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class GitClientTests
    {
        [Test]
        public void TestMethod()
        {
            var c = new GitClient(@"D:\xampp\htdocs\red\sugal");
            var files = c.DiffFiles();
        }
    }
}
