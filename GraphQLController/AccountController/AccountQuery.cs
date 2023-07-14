using Bank.Model;
using Bank.Services;

namespace Bank
{
    public class AccountQuery
    {
        private readonly IAccountService _service;
        public AccountQuery(IAccountService service) {
            _service = service;
        }

        public List<Account> GetAccounts()
        {
            var accounts = _service.GetAccounts();
            return accounts;
            
        }

        public decimal Saldo(int conta)
        {
            var accNumber = conta.ToString();
            return _service.GetAcountBalance(accNumber);
        }

    }
}