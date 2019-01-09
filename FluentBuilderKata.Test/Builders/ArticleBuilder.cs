namespace FluentBuilderKata.Test.Builders
{
    public class ArticleBuilder
    {
        private decimal _price;
        private string _name;
        private string _category;

        public static ArticleBuilder Article() =>
            new ArticleBuilder()
                .Named("some name")
                .InCategory("some category")
                .WithPrice(100m);

        internal ArticleBuilder InCategory(string category)
        {
            _category = category;
            return this;
        }

        private ArticleBuilder Named(string name)
        {
            _name = name;
            return this;
        }

        public ArticleBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public ArticleBuilder WithoutName()
        {
            _name = null;
            return this;
        }

        public ArticleBuilder WithoutCategory()
        {
            _category = null;
            return this;
        }

        public Article Build()
        {
            return new Article
            {
                Name = _name,
                Category = _category,
                Price = _price
            };
        }
    }
}