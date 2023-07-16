using Bank.Model;
using Bank.Services;

namespace Bank
{
    public class AccountQuery
    {
        public AccountQuery() {}

        public List<Account> GetAccounts([Service] IAccountService _service)
        {
            var accounts = _service.GetAccounts();
            return accounts;
            
        }

        public decimal Saldo(int conta, [Service] IAccountService _service)
        {
            var value = _service.GetAcountBalance(conta);
            return value;
        }

    }
}