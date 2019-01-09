using System;
using FluentAssertions;
using Xunit;
using static FluentBuilderKata.Test.Builders.TransactionBuilder;

namespace FluentBuilderKata.Test
{
    public class TransactionFieldsTest
    {
        private readonly Logic _sut;

        public TransactionFieldsTest()
        {
            _sut = new Logic();
        }

        [Fact]
        public void should_not_close_a_transaction_twice()
        {
            var transaction = EmptyTransaction()
                .Closed(true)
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close an already closed transaction");
        }

        [Fact]
        public void should_print_an_empty_transaction()
        {
            var transaction = EmptyTransaction()
                .ToPrint(true)
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Empty transaction has been closed and printed");
        }

        [Fact]
        public void should_just_close_a_transaction()
        {
            var transaction = EmptyTransaction()
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be("Empty transaction has been closed");
        }
        
        [Theory]
        [InlineData(1, "Empty transaction has been closed")]
        [InlineData(2, "Empty transaction has been closed")]
        [InlineData(3, "Empty transaction has been closed")]
        [InlineData(4, "Empty transaction has been closed")]
        [InlineData(5, "Empty transaction has been closed")]
        [InlineData(6, "Empty transaction has been closed")]
        [InlineData(7, "Empty transaction has been closed")]
        [InlineData(8, "Cannot close transactions created on vacation month")]
        [InlineData(9, "Empty transaction has been closed")]
        [InlineData(10, "Empty transaction has been closed")]
        [InlineData(11, "Empty transaction has been closed")]
        [InlineData(12, "Cannot close transactions created on vacation month")]
        public void transactions_must_be_created_on_working_months(int month, string expected)
        {
            var transaction = EmptyTransaction()
                .CreatedOnMonth(month)
                .Build();

            var result = _sut.Close(transaction);

            result.Should().Be(expected);
        }
    }
}