using System;

namespace FluentBuilderKata
{
    public class Logic
    {
        public string Close(Transaction transaction)
        {
            if (transaction.Closed)
                return "Cannot close an already closed transaction";
            throw new NotImplementedException();
        }
    }
}