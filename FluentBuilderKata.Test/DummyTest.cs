using FluentAssertions;
using Xunit;

namespace FluentBuilderKata.Test
{
    public class DummyTest
    {
        [Fact]
        public void should_pass()
        {
            "friends".Should().Be("friends");
        }
    }
}