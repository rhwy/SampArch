using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SampArch.Domain.Ideas;
using SampArch.Domain.Common;

namespace SampArch.Domain.Tests
{
    [TestFixture]
    public class IdeasTests
    {
        private Idea _suggest;

        [SetUp]
        public void Setup()
        {
            _suggest = new Idea();
        }

        [Test]
        public void ensure_suggest_can_add_comment()
        {
            _suggest.AddComment(new Comment { Content = "test" });
            Assert.That(_suggest.Comments.Count, Is.EqualTo(1));
        }

        [Test]
        public void ensure_suggest_can_vote_up()
        {
            _suggest.VoteUp();
            Assert.That(_suggest.Votes.Up, Is.EqualTo(1));
        }

        [Test]
        public void ensure_suggest_can_vote_down()
        {
            _suggest.VoteDown();
            Assert.That(_suggest.Votes.Down, Is.EqualTo(1));
        }

        [Test]
        public void ensure_suggest_can_add_tag()
        {
            Tag actual = new Tag("test");
            _suggest.AddTag(actual);
            Assert.That(_suggest.Tags.Count, Is.EqualTo(1));
            Assert.That(_suggest.Tags.FirstOrDefault(), Is.EqualTo(actual));
        }

        [Test]
        public void ensure_suggest_can_add_tag_from_string()
        {
            string tagName = "test";
            _suggest.AddTag(tagName);
            Assert.That(_suggest.Tags.Count, Is.EqualTo(1));
            Assert.That(_suggest.Tags.FirstOrDefault().Name, Is.EqualTo(tagName));
        }

        [Test]
        public void ensure_suggest_can_remove_tag()
        {
            Tag tag = new Tag("test");
            _suggest.AddTag(tag);
            _suggest.RemoveTag(tag);
            Assert.That(_suggest.Tags.Count, Is.EqualTo(0));
        }

        [Test]
        public void ensure_suggest_can_remove_tag_from_name()
        {
            Tag tag = new Tag("test");
            _suggest.AddTag(tag);
            _suggest.RemoveTag("test");
            Assert.That(_suggest.Tags.Count, Is.EqualTo(0));
        }
    }
}
