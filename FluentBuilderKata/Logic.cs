namespace FluentBuilderKata
{
    public class Logic
    {
        public string Close(Transaction transaction)
        {
            if (transaction.Closed)
                return "Cannot close an already closed transaction";

            if (transaction.ToPrint)
                return "Transaction has been closed and printed";

            if (transaction.Created.Month == 8 || transaction.Created.Month == 12)
                return "Cannot close transactions created on vacation month";

            return "Transaction has been closed";
        }
    }
}