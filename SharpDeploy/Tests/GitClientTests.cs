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
            var files = c.DiffFiles("9ca499682524d4ec402a1f8297edd92c0de1ccf7", "c773b84fc1accc2e2c4fa4138cb03c909c06ad2f");
            foreach (var f in files) {
                Console.WriteLine(f);
            }
        }
    }
}
