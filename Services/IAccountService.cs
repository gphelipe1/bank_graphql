using Bank.Model;

namespace Bank.Services
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        decimal GetAcountBalance(int accNumber);
        Account Withdraw(int accNumber, decimal valor);
        Account Deposit(int accNumber, decimal value);
    }
}