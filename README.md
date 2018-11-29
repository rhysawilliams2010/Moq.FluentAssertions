# Moq.FluentAssertions

A helper library to use the power of [fluentassertions](https://fluentassertions.com/) with [moq](https://github.com/moq/moq4) It.Is matchers.

Moq.FluentAssertions makes it easy to see which arguments failed to match a Setup or Verify.

Use it like so:
```
  Mock.Of<MyService>.Setup(x=>x.DoSomething(It.Is(Equivalent.To<Something>(new {Value="Something"})));
```

Install from [nuget](https://www.nuget.org/packages/RhysAWilliams.Moq.FluentAssertions/):
```
  Install-Package RhysAWilliams.Moq.FluentAssertions
```
