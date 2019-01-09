using System;
using FluentAssertions;
using Xunit;

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
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "iPad",
                    Category = "Electronics",
                    Price = 420m
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 420");
        }

        [Fact]
        public void should_refuse_articles_without_a_name()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Category = "Electronics",
                    Price = 420m
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close: invalid article");
        }

        [Fact]
        public void should_refuse_articles_without_a_category()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "iPad",
                    Price = 420m
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close: invalid article");
        }

        [Fact]
        public void should_print_a_transaction()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = true,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "iPad",
                    Category = "Electronics",
                    Price = 420m
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 420. Transaction printed.");
        }

        [Fact]
        public void transaction_with_alcoholics_must_have_adult_customer()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "Beer",
                    Category = "Alcoholics",
                    Price = 4m
                },
                Customer = new Customer
                {
                    Name = "Mario",
                    Surname = "Cioni",
                    BornOn = new DateTime(1992, 3, 25)
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Spent 4");
        }

        [Fact]
        public void alcoholics_cannot_be_sold_to_minors()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "Beer",
                    Category = "Alcoholics",
                    Price = 4m
                },
                Customer = new Customer
                {
                    Name = "Mario",
                    Surname = "Cioni",
                    BornOn = new DateTime(2005, 3, 25)
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot sell this article to minors");
        }

        [Fact]
        public void selling_alcoholics_requires_a_customer()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = true,
                Created = new DateTime(2018, 2, 25),
                Article = new Article
                {
                    Name = "Beer",
                    Category = "Alcoholics",
                    Price = 4m
                }
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot sell this article if no customer is specified");
        }
    }
}