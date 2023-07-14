using Bank.Model;

namespace Bank.Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAll();
        Account GetByAccountNumber(string accNumber);
        Account Save(Account acc);
        Account Update(Account acc);
        Account Delete(Account acc);
        Account? Deposit(string accNumber, decimal value);
    }
}