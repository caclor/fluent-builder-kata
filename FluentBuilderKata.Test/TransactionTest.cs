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
    }
}