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
            var files = c.DiffFiles("171adcad2bb8af1fa98f2fca48fbf01bf4631a1a", "5d71ebd7384f2d4bfbaf9ef76e5cf0a32f4a12ad");
            foreach (var f in files) {
                Console.WriteLine(f);
            }
        }
    }
}
