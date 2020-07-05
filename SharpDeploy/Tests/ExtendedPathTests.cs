using System;
using NUnit.Framework;

namespace SharpDeploy.Tests
{
    [TestFixture]
    public class ExtendedPathTests
    {
        [Test]
        public void TestMethod()
        {
            var p = ExtendedPath.GetPath(@"test.txt\some\test.txt");
        }
    }
}
