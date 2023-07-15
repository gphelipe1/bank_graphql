using Bank.Model;

namespace Bank.Repositories
{
    public interface IAccountRepository
    {
        List<Account> GetAll();
        Account? GetByAccountNumber(int accNumber);
        Task<Account> Save(Account acc);
        Task<Account> Update(Account acc);
        Account Delete(Account acc);
        Task<Account?> Deposit(int accNumber, decimal value);
    }
}