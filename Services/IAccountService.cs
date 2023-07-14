using Bank.Model;

namespace Bank.Services
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        decimal GetAcountBalance(string accNumber);
    }
}