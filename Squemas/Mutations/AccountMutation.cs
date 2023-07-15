using Bank.Model;
using Bank.Services;

namespace Bank
{
    public class AccountMutation
    {
        private readonly IAccountService _service;
        public AccountMutation(IAccountService service) {
            _service = service;
        }

        public Account Depositar(int conta, decimal valor)
        {
            var deposited = _service.Deposit(conta, valor);

            return deposited;
        }

        public Account Sacar(int conta, decimal valor)
        {
            var account = _service.Withdraw(conta, valor);

            return account;
        }

    }
}