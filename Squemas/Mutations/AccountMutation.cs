using Bank.Model;
using Bank.Services;
using Moq;

namespace Bank
{
    public class AccountMutation
    {
        public AccountMutation() {}

        public async Task<Account> Depositar(int conta, decimal valor, [Service] IAccountService _service)
        {
            var deposited = await _service.Deposit(conta, valor);

            return deposited;
        }

        public async Task<Account> Sacar(int conta, decimal valor, [Service] IAccountService _service)
        {
            var account = await _service.Withdraw(conta, valor);

            return account;
        }

        public async Task<Account> Criar(int conta, [Service] IAccountService _service)
        {
            var createdAccount = await _service.Create(conta);

            return createdAccount;
        }

        public async Task<Account> Deletar(int conta, [Service] IAccountService _service)
        {
            var accountDeleted = await _service.Delete(conta);

            return accountDeleted;
        }

    }
}