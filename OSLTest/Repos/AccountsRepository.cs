namespace OSLTest.Repos
{
    public class AccountsRepository : IAccountsRepository
    {
        //I run out of time to implement storing accounts and transactions in db or in-memory so I emulated the methods.
        public Account GetAccount(string accountId)
        {
            return new Account();
        }

        public Transaction GetTransactions(string accountId)
        {
            return new Transaction();
        }

        public void PostAccount(Account account) 
        { 
        
        }

        public void PostDebit(Debit debit)
        {

        }

        public void PostCredit(Credit credit)
        {

        }

    }

    public interface IAccountsRepository
    {
        public Account GetAccount(string accountId);
        public Transaction GetTransactions(string accountId);
        public void PostAccount(Account account);
        public void PostDebit(Debit debit);
        public void PostCredit(Credit credit);
    }
}
