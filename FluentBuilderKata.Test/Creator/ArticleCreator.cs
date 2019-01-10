using System;
using System.Collections.Generic;
using System.Text;
using static FluentBuilderKata.Test.Creator.DiscountCreator;

namespace FluentBuilderKata.Test.Creator
{
  internal class ArticleCreator
  {
    public decimal _price;
    private string _name;
    private string _category;
    private DiscountCreator _discountCreated;

    internal static ArticleCreator CreateArticle()
    {
      return new ArticleCreator().WithPrice(1).WithName("default name").WithCategory("default category");
    }

    internal ArticleCreator WithName(string name)
    {
      _name = name;
      return this;
    }
    internal ArticleCreator WithCategory(string category)
    {
      _category = category;
      return this;
    }
    internal ArticleCreator WithPrice(decimal price)
    {
      _price = price;
      return this;
    }

    internal ArticleCreator Discounted(Func<DiscountCreator,DiscountCreator> func)
    {
      _discountCreated = CreateDiscount();
      _discountCreated = func(_discountCreated);
      return this;
    }

    internal Article Create()
    {
      return new Article
      {
        Name = _name,
        Price = _price,
        Category = _category,
        Discount = _discountCreated?.Create()
      };
    }
  }
}
