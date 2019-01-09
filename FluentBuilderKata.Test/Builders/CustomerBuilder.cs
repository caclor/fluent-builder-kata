using System;

namespace FluentBuilderKata.Test.Builders
{
    public class CustomerBuilder
    {
        private int _age;

        public static CustomerBuilder Customer() =>
            new CustomerBuilder();

        public Customer Build()
        {
            return new Customer
            {
                Name = "Mario",
                Surname = "Cioni",
                BornOn = DateTime.Now.AddYears(-_age)
            };
        }

        public CustomerBuilder Aged(int age)
        {
            _age = age;
            return this;
        }
    }
}