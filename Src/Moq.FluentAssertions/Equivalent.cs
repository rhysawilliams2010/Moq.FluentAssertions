namespace Moq.FluentAssertions
{
    using System;
    using System.Linq.Expressions;

    using global::FluentAssertions;

    public static class Equivalent
    {
        public static Expression<Func<TValue, bool>> To<TValue>(dynamic to)
        {
            Func<TValue, bool> f = @from =>
                {
                    from.Should().BeEquivalentTo(to);
                    return true;
                };
            Expression<Func<TValue, bool>> match = from => f(from);
            return match;
        }
    }
}
