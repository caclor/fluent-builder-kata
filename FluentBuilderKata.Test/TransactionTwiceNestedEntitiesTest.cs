using System;
using FluentAssertions;
using Xunit;
using static FluentBuilderKata.Test.Builders.TransactionBuilder;

namespace FluentBuilderKata.Test
{
    public class TransactionTwiceNestedEntitiesTest
    {
        private readonly Logic _sut;

        public TransactionTwiceNestedEntitiesTest()
        {
            _sut = new Logic();
        }

        [Fact]
        public void should_print_the_discount_percentage()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .WithPrice(1)
                    .HavingDiscount(d => d
                        .WithAmount(10))
                )
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 1. Discount on next transaction 10%");
        }

        [Fact]
        public void discount_must_have_a_name()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .HavingDiscount(d => d
                        .WithoutAName())
                )
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Invalid discount");
        }
    }
}