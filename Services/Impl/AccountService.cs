using Bank.Context;
using Bank.Model;
using Bank.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bank.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public AccountService(IAccountRepository repository, IServiceProvider serviceProvider)
        {
            _repository = repository;
            _serviceProvider = serviceProvider;
        }

        public async Task<Account> Create(int accNumber) {
            var checkAcc = _repository.GetByAccountNumber(accNumber);

            if(checkAcc != null){
                throw new Exception("Conta já existente no banco.");
            }

            var newAccount = new Account();

            newAccount.Conta = accNumber;

            var accountCreated = await _repository.Save(newAccount);

            return accountCreated;
        }

        public async Task<Account> Delete(int accNumber) {
            var account = _repository.GetByAccountNumber(accNumber);
            
            if (account == null)  
                throw new Exception("Conta não encontrada.");

            if (account.Saldo > 0)
                throw new Exception("Ação negada. Por favor, saque o valor da conta.");

            var deletedAccount = await _repository.Delete(account);

            return deletedAccount;
        }

        public List<Account> GetAccounts(){
            var accounts = _repository.GetAll();

            return accounts;
        }

        public async Task<Account> Withdraw(int accNumber, decimal valor)
        {
            var conta = _repository.GetByAccountNumber(accNumber);
            
            if (conta == null)  
                throw new Exception("Conta não encontrada.");

            if (valor > conta.Saldo)
                throw new Exception("Saldo insuficiente.");

            conta.Saldo -= valor;
            var updated = await _repository.Update(conta);

            return updated;
        }

        public async Task<Account> Deposit(int accNumber, decimal value)
        {
            var account = await _repository.Deposit(accNumber, value);

            if (account == null)
                throw new Exception("Conta não encontrada.");

            return account;
        }

        public decimal GetAcountBalance(int accNumber)
        {
            var acc =  _repository.GetByAccountNumber(accNumber);
            if (acc == null)
                throw new Exception("Conta não encontrada.");

            return acc.Saldo;
        }
    }
}