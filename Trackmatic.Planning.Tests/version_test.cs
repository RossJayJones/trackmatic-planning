using NUnit.Framework;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Tests
{
    [TestFixture]
    public class version_test
    {
        [Test]
        public void increment_should_increase_the_version_number()
        {
            var version = new Version(new UserReference());

            Assert.AreEqual(0, version.Id);

            version = version.Increment(new UserReference());

            Assert.AreEqual(1, version.Id);
        }
    }
}
