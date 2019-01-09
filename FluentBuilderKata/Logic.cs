using System;

namespace FluentBuilderKata
{
    public class Logic
    {
        public string Close(Transaction transaction)
        {
            if (transaction.Closed)
                return "Cannot close an already closed transaction";

            if (transaction.ToPrint)
                if(transaction.Article == null)
                    return "Empty transaction has been closed and printed";

            if (transaction.Created.Month == 8 || transaction.Created.Month == 12)
                return "Cannot close transactions created on vacation month";

            if (transaction.Article == null)
                return "Empty transaction has been closed";

            if (transaction.Article.IsValid())
            {
                if (transaction.Article.Category == "Alcoholics")
                {
                    if (transaction.Customer == null)
                        return "Cannot sell this article if no customer is specified";

                    var timeSpan = DateTime.Now.Subtract(transaction.Customer.BornOn);
                    var age = new DateTime(timeSpan.Ticks).Year;
                    if (age <= 18)
                        return "Cannot sell this article to minors";
                }

                if(transaction.ToPrint)
                    return $"Spent {transaction.Article.Price}. Transaction printed.";
                return $"Spent {transaction.Article.Price}";
            }

            return "Cannot close: invalid article";
        }
    }
}