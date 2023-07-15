using Bank.Model;

namespace Bank.Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAll();
        Account? GetByAccountNumber(int accNumber);
        Account Save(Account acc);
        Account Update(Account acc);
        Account Delete(Account acc);
        Account? Deposit(int accNumber, decimal value);
    }
}