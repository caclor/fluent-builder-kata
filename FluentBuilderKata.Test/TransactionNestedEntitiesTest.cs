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
    }
}