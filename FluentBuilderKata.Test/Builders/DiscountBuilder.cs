namespace FluentBuilderKata.Test.Builders
{
    public class DiscountBuilder
    {
        private int _amount;
        private string _name;

        private DiscountBuilder()
        {

        }
        public DiscountBuilder WithAmount(int amount)
        {
            _amount = amount;
            return this;
        }

        public Discount Build()
        {
            return new Discount
            {
                Name = _name,
                Amount = _amount
            };
        }

        public DiscountBuilder WithoutAName()
        {
            _name = null;
            return this;
        }

        public static DiscountBuilder Discount() =>
            new DiscountBuilder()
                .WithName("some name");

        private DiscountBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}