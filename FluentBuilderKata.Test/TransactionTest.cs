using System;
using FluentAssertions;
using Xunit;

namespace FluentBuilderKata.Test
{
    public class TransactionTest
    {
        private readonly Logic _sut;

        public TransactionTest()
        {
            _sut = new Logic();
        }

        [Fact]
        public void should_not_close_a_transaction_twice()
        {
            var transaction = new Transaction
            {
                Closed = true
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Cannot close an already closed transaction");
        }

        [Fact]
        public void should_print_a_transaction()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = true
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Transaction has been closed and printed");
        }

        [Fact]
        public void should_just_close_a_transaction()
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false
            };

            var result = _sut.Close(transaction);

            result.Should().Be("Transaction has been closed");
        }
        
        [Theory]
        [InlineData(1, "Transaction has been closed")]
        [InlineData(2, "Transaction has been closed")]
        [InlineData(3, "Transaction has been closed")]
        [InlineData(4, "Transaction has been closed")]
        [InlineData(5, "Transaction has been closed")]
        [InlineData(6, "Transaction has been closed")]
        [InlineData(7, "Transaction has been closed")]
        [InlineData(8, "Cannot close transactions created on vacation month")]
        [InlineData(9, "Transaction has been closed")]
        [InlineData(10, "Transaction has been closed")]
        [InlineData(11, "Transaction has been closed")]
        [InlineData(12, "Cannot close transactions created on vacation month")]
        public void transactions_must_be_created_on_working_months(int month, string expected)
        {
            var transaction = new Transaction
            {
                Closed = false,
                ToPrint = false,
                Created = new DateTime(2018, month, 25)
            };

            var result = _sut.Close(transaction);

            result.Should().Be(expected);
        }
    }
}