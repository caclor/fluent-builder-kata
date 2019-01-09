using System;
using FluentAssertions;
using FluentBuilderKata.Test.Builders;
using Xunit;
using static FluentBuilderKata.Test.Builders.TransactionBuilder;

namespace FluentBuilderKata.Test
{
    public class TransactionNestedEntitiesTest
    {
        private readonly Logic _sut;

        public TransactionNestedEntitiesTest()
        {
            _sut = new Logic();
        }

        [Fact]
        public void should_calculate_the_total()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .WithPrice(420))
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 420");
        }

        [Fact]
        public void should_refuse_articles_without_a_name()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .WithoutName())
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close: invalid article");
        }

        [Fact]
        public void should_refuse_articles_without_a_category()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .WithoutCategory())
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close: invalid article");
        }

        [Fact]
        public void should_print_a_transaction()
        {
            var transaction = Transaction()
                .ToPrint(true)
                .HavingArticle(a => a
                    .WithPrice(420m))
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 420. Transaction printed.");
        }

        [Fact]
        public void transaction_with_alcoholics_must_have_adult_customer()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .InCategory("Alcoholics")
                    .WithPrice(4m))
                .HavingCustomer(c => c
                    .Aged(22))
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 4");
        }

        [Fact]
        public void alcoholics_cannot_be_sold_to_minors()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .InCategory("Alcoholics")
                    .WithPrice(4m))
                .HavingCustomer(c => c
                    .Aged(17))
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot sell this article to minors");
        }

        [Fact]
        public void selling_alcoholics_requires_a_customer()
        {
            var transaction = Transaction()
                .HavingArticle(a => a
                    .InCategory("Alcoholics")
                    .WithPrice(4m))
                .HavingNoCustomer()
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot sell this article if no customer is specified");
        }
    }
}