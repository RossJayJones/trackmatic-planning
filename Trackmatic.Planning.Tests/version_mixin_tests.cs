using System.Linq;
using NUnit.Framework;
using Trackmatic.Common.Model;
using Trackmatic.Planning.Framework;

namespace Trackmatic.Planning.Tests
{
    [TestFixture]
    public class version_mixin_tests
    {
        [Test]
        public void edit_should_increment_the_number_of_versions()
        {
            var mixin = new VersionMixin<DummyVerion>(new DummyVerion());

            Assert.AreEqual(1, mixin.Versions.Count());

            mixin.Edit(new UserReference());

            Assert.AreEqual(2, mixin.Versions.Count());
        }

        private class DummyVerion : IVersion<DummyVerion>
        {
            public DummyVerion Edit(UserReference user)
            {
                return new DummyVerion();
            }

            public Version Version { get; }
        }
    }
}
