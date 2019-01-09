using System;

namespace FluentBuilderKata.Test.Builders
{
    public class TransactionBuilder
    {
        private bool _closed;
        private bool _toPrint;
        private int _creationMonth;
        private ArticleBuilder _articleBuilder;
        private CustomerBuilder _customerBuilder;

        private TransactionBuilder(ArticleBuilder articleBuilder, CustomerBuilder customerBuilder)
        {
            _articleBuilder = articleBuilder;
            _customerBuilder = customerBuilder;
        }

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
                Created = new DateTime(2017, _creationMonth, 22),
                Article = _articleBuilder?.Build(),
                Customer = _customerBuilder?.Build()
            };

        public static TransactionBuilder EmptyTransaction() =>
            new TransactionBuilder(null, null)
                .Closed(false)
                .CreatedOnMonth(1)
                .ToPrint(false);

        public static TransactionBuilder Transaction() =>
            new TransactionBuilder(ArticleBuilder.Article(), CustomerBuilder.Customer())
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

        public TransactionBuilder HavingArticle(Func<ArticleBuilder, ArticleBuilder> func)
        {
            _articleBuilder = func(_articleBuilder);
            return this;
        }

        public TransactionBuilder HavingCustomer(Func<CustomerBuilder, CustomerBuilder> func)
        {
            _customerBuilder = func(_customerBuilder);
            return this;
        }

        public TransactionBuilder HavingNoCustomer()
        {
            _customerBuilder = null;
            return this;
        }
    }
}