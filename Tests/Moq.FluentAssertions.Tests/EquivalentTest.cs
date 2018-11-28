namespace Moq.FluentAssertions.Tests
{
    using System;

    using AutoFixture;

    using global::FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EquivalentTest
    {
        private Fixture fixture;

        private ITestService service;

        private TestObject @from;

        [TestInitialize]
        public void TestInitialize()
        {
            this.fixture = new Fixture();
            this.service = Mock.Of<ITestService>();
            this.from = this.fixture.Create<TestObject>();
            this.service.DoSomething(this.from);
        }

        [TestMethod]
        public void MatchesDynamicObject()
        {
            Mock.Get(this.service).Verify(
                x => x.DoSomething(
                    It.Is(
                        Equivalent.To<TestObject>(
                            new
                                {
                                    Value = this.@from.Value, Child = new { ChildValue = this.@from.Child.ChildValue }
                                }))));
        }

        [TestMethod]
        public void RejectsDynamicObjectMismatch()
        {
            Action act = () =>
                {
                    Mock.Get(this.service).Verify(
                        x => x.DoSomething(
                            It.Is(Equivalent.To<TestObject>(new { Value = this.fixture.Create<string>() }))));
                };
            act.Should().Throw<AssertFailedException>();
        }

        [TestMethod]
        public void MatchesTypedObject()
        {
            Mock.Get(this.service).Verify(x => x.DoSomething(It.Is(Equivalent.To<TestObject>(this.from))));
        }

        [TestMethod]
        public void RejectsTypedObjectMismatch()
        {
            Action act = () =>
                {
                    Mock.Get(this.service).Verify(
                        x => x.DoSomething(It.Is(Equivalent.To<TestObject>(this.fixture.Create<TestObject>()))));
                };
            act.Should().Throw<AssertFailedException>();
        }
    }
}