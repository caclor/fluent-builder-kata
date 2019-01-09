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

            return "Transaction has been closed";
        }
    }
}