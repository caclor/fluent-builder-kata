using System;

namespace FluentBuilderKata
{
    public class Transaction
    {
        public bool Closed { get; set; }
        public bool ToPrint { get; set; }
        public DateTime Created { get; set; }
        public Article Article { get; set; }
        public Customer Customer { get; set; }
    }
}