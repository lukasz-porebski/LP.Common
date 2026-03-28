using FluentAssertions;
using LP.Common.Shared.Extensions;
using Xunit;

namespace Shared.Tests.Extensions;

public class EnumExtensionsTests
{
    [Fact]
    public void ValueToStringMethod_Should_ReturnEnumIntValueAsString()
    {
        var result = TestEnum.Value1.ValueToString();

        result.Should().Be("1");
    }

    private enum TestEnum
    {
        Value1 = 1
    }
}