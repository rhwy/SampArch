using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SampArch.Domain.Common;

namespace SampArch.Domain.Tests
{
    [TestFixture]
    public class TagTests
    {
        [Test]
        public void Tag_should_be_equal_if_the_name_is_equal()
        {
            Tag tagSource = new Tag("test");
            Tag tagTarget = new Tag("test");
            Assert.That(tagTarget, Is.EqualTo(tagTarget));
        }
    }
}
