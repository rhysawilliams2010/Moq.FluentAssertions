namespace Moq.FluentAssertions.Tests
{
    public class TestObject
    {
        public string Value { get; set; }

        public string OtherValue { get; set; }

        public TestChild Child { get; set; }

#pragma warning disable CA1034 // Nested types should not be visible
        public class TestChild
#pragma warning restore CA1034 // Nested types should not be visible
        {
            public int ChildValue { get; set; }
        }
    }
}