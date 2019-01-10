using System;
using FluentAssertions;
using Xunit;
using static FluentBuilderKata.Test.Creator.TransactionCreator;

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
      //var transaction = new Transaction
      //{
      //  Closed = false,
      //  ToPrint = false,
      //  Created = new DateTime(2018, 2, 25),
      //  Article = new Article
      //  {
      //    Name = "Apple",
      //    Category = "Fruits",
      //    Price = 1m,
      //    Discount = new Discount
      //    {
      //      Name = "Happy meal",
      //      Amount = 10
      //    }
      //  }
      //};
      var transaction = Transaction()
        .WithTheArticles(a => a
          .WithPrice(1)
          .Discounted(d => d.Amount(10)))
        .Create();

      var result = _sut.Close(transaction);

      result.Should().Be("Spent 1. Discount on next transaction 10%");
    }

    [Fact]
    public void discount_must_have_a_name()
    {
      //var transaction = new Transaction
      //{
      //  Closed = false,
      //  ToPrint = false,
      //  Created = new DateTime(2018, 2, 25),
      //  Article = new Article
      //  {
      //    Name = "Apple",
      //    Category = "Fruits",
      //    Price = 1m,
      //    Discount = new Discount
      //    {
      //      Name = null,
      //      Amount = 10
      //    }
      //  }
      //};

      var transaction = Transaction()
        .WithTheArticles(a => a
          .Discounted(d => d
            .DiscountName(null)))
          .Create();

      var result = _sut.Close(transaction);

      result.Should().Be("Invalid discount");
    }
  }
}