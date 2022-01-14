using System;

namespace Xunit.Categories.Test
{
    public class Scratch
    {
        [Fact]
        public void Test()
        {
            throw new NotImplementedException("just the facts");
        }

        [Fact]
        [Bug]
        public void TestBug()
        {
            throw new NotImplementedException("I'm a bug");
        }

        [Fact]
        [Bug(777)]
        [Bug("777")]
        public void TestBugWithId()
        {
            throw new NotImplementedException("I've got your number");
        }

        [Fact, IntegrationTest]
        [Feature(888)]
        [Feature("888")]
        public void TestFeatureWithId()
        {
            throw new NotImplementedException("I've got your feature");
        }

        [Fact]
        [KnownBug]
        public void TestKnownBug()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [KnownBug(666)]
        [KnownBug("666 a")]
        public void TestKnownBugWithId()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [Documentation]
        [Documentation(666)]
        [Documentation("666 a")]
        public void TestDocumentation()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [Exploratory]
        [Exploratory(666)]
        [Exploratory("666 a")]
        public void TestExploratory()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [WorkItem]
        [WorkItem(666)]
        [WorkItem("666 a")]
        public void TestWorkItem()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [SystemTest]
        [SystemTest(666)]
        [SystemTest("666 a")]
        public void TestSystemTest()
        {
            throw new NotImplementedException("request #8 - This is more black box, high level, and stress testing of a complete running application different to an IntegrationTest");
        }

        [Fact]
        [WorkItem]
        [WorkItem(999)]
        [WorkItem("999")]
        public void TestTestCase()
        {
            throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }

        [Fact]
        [LocalTest]
        [LocalTest(666)]
        [LocalTest("666 a")]
        public void TestLocalTest()
        {
	        throw new NotImplementedException("I'm not that important, all the world knows about me, I'll be fixed in 2030");
        }
    }
}