using System;
using System.Collections.Generic;
using System.Text;
using static FluentBuilderKata.Test.Creator.ArticleCreator;
using static FluentBuilderKata.Test.Creator.CustomerCreator;

namespace FluentBuilderKata.Test.Creator
{
  internal class TransactionCreator
  {
    private bool _close;
    private bool _toPrint;
    private int _month;
    private ArticleCreator _articleCreated;
    private CustomerCreator _customerCreated;

    internal static TransactionCreator Transaction()
    {
      return new TransactionCreator().IsClosed(false).ToBePrint(false).MadeOn(1);
    }

    internal TransactionCreator IsClosed(bool close)
    {
      _close = close;
      return this;
    }

    internal TransactionCreator ToBePrint(bool toPrint)
    {
      _toPrint = toPrint;
      return this;
    }
    internal TransactionCreator MadeOn(int month)
    {
      _month = month;
      return this;
    }

    internal TransactionCreator WithTheArticles(Func<ArticleCreator, ArticleCreator> function)
    {
      _articleCreated = CreateArticle();
      _articleCreated = function(_articleCreated);
      
      return this;
    }

    internal TransactionCreator WithCustomer(Func<CustomerCreator, CustomerCreator> func)
    {
      _customerCreated = CreateCustomer();
      _customerCreated = func(_customerCreated);
      return this;
    }

    internal Transaction Create()
    {
      return new Transaction()
      {
        Closed = _close,
        ToPrint = _toPrint,
        Created = new DateTime(2018, _month, 01),
        Article = _articleCreated?.Create(),
        Customer = _customerCreated?.Create()
      };
    }

    
  }
}
