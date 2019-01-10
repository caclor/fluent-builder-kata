using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilderKata.Test.Creator
{
  internal class DiscountCreator
  {
    private decimal _discountAmount;
    private string _discountName;

    internal static DiscountCreator CreateDiscount()
    {
      return new DiscountCreator().Amount(0).DiscountName("default name");
    }

    internal DiscountCreator Amount(decimal discountAmount)
    {
      _discountAmount = discountAmount;
      return this;
    }

    internal DiscountCreator DiscountName(string discountName)
    {
      _discountName = discountName;
      return this;
    }

    internal Discount Create()
    {
      return new Discount()
      {
        Amount = _discountAmount,
        Name = _discountName
      };
    }
  }
}
