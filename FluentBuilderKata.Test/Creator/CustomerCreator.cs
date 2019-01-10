using System;
using System.Collections.Generic;
using System.Text;


namespace FluentBuilderKata.Test.Creator
{
  internal class CustomerCreator
  {
    private int _year;
    private int _month;
    private int _day;
    private string _name;
    private string _surname;

    internal static CustomerCreator CreateCustomer()
    {
      return new CustomerCreator().Born(1900, 01, 01).Name("default name").Surname("default surname");
    }

    internal CustomerCreator Born(int year, int month, int day)
    {
      _year = year;
      _month = month;
      _day = day;
      return this;
    }

    internal CustomerCreator Name(string name)
    {
      _name = name;
      return this;
    }

    internal CustomerCreator Surname(string surname)
    {
      _surname = surname;
      return this;
    }

    internal Customer Create()
    {
      return new Customer
      {
        BornOn = new DateTime(_year, _month, _day),
        Surname = _surname,
        Name = _name
      };
    }
  }
}
