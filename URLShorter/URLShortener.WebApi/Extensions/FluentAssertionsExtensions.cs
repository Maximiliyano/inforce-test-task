using System.Linq.Expressions;
using FluentAssertions.Equivalency;

namespace FluentAssertions;

public static class FluentAssertionsExtensions
{
    public static EquivalencyAssertionOptions<TExpectation> Including<TExpectation>(
        this EquivalencyAssertionOptions<TExpectation> options,
        params Expression<Func<TExpectation, object>>[] expressions)
    {
        foreach (var expression in expressions)
            options.Including(expression);

        return options;
    }
    
    public static EquivalencyAssertionOptions<TExpectation> Excluding<TExpectation>(
        this EquivalencyAssertionOptions<TExpectation> options,
        params Expression<Func<TExpectation, object>>[] expressions)
    {
        foreach (var expression in expressions)
            options.Excluding(expression);

        return options;
    }
}