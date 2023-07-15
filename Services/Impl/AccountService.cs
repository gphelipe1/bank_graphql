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