namespace FluentBuilderKata
{
    public class Article
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Discount Discount { get; set; }

        public bool IsValid() => !(string.IsNullOrEmpty(Category) || string.IsNullOrEmpty(Name));
    }
}