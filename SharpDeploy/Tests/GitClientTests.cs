using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class GitClientTests
    {
        [Test]
        public void TestDiffFilles()
        {
            var c = new GitClient(@"D:\xampp\htdocs\red\sugal");
            var files = c.DiffFiles();
            foreach (var f in files) {
                Console.WriteLine(f);
            }
        }
    }
}
