using Bank.Model;

namespace Bank.Services
{
    public interface IAccountService
    {
        Task<Account> Create(int accNumber);
        Task<Account> Delete(int accNumber);
        List<Account> GetAccounts();
        decimal GetAcountBalance(int accNumber);
        Task<Account> Withdraw(int accNumber, decimal valor);
        Task<Account> Deposit(int accNumber, decimal value);
    }
}