using System;

namespace FluentBuilderKata.Test.Builders
{
    public class TransactionBuilder
    {
        private bool _closed;
        private bool _toPrint;
        private int _creationMonth;

        public TransactionBuilder Closed(bool closed)
        {
            _closed = closed;
            return this;
        }

        public Transaction Build() =>
            new Transaction
            {
                Closed = _closed,
                ToPrint = _toPrint,
                Created = new DateTime(2017, _creationMonth, 22)
            };

        public static TransactionBuilder Transaction() =>
            new TransactionBuilder()
                .Closed(false)
                .CreatedOnMonth(1)
                .ToPrint(false);

        public TransactionBuilder ToPrint(bool toPrint)
        {
            _toPrint = toPrint;
            return this;
        }

        public TransactionBuilder CreatedOnMonth(int month)
        {
            _creationMonth = month;
            return this;
        }
    }
}