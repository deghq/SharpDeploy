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
            var c = new GitClient(@"D:\Contrib\SharpDeploy");
            var files = c.DiffFiles("b1f3d8b8d367205ee3d356c86aef2a5d2b1f5a63");
            foreach (var f in files) {
                Console.WriteLine(f);
            }
        }
    }
}
