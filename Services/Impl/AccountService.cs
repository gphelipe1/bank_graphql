using Bank.Model;
using Bank.Repositories;

namespace Bank.Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _repository;
        public AccountService(IAccountRepository repository) {
            _repository = repository;
        }

        public List<Account> GetAccounts(){
            var accounts = _repository.GetAll();

            return accounts;
        }

        public Account Deposit(string accNumber, decimal value)
        {
            var account = _repository.Deposit(accNumber, value);

            if (account == null)
                throw new Exception("Conta não encontrada.");

            return account;
        }

        public decimal GetAcountBalance(string accNumber)
        {
            var acc =  _repository.GetByAccountNumber(accNumber);
            if (acc == null)
                throw new Exception("Conta não encontrada.");

            return acc.Saldo;
        }
    }
}