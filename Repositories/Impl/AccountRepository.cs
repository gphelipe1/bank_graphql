using Bank.Context;
using Bank.Model;

namespace Bank.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly ApiContext _context;

        public AccountRepository(IServiceProvider serviceProvider)
        {
            _context = serviceProvider.GetRequiredService<ApiContext>();
        }

        public List<Account> GetAll() {
            var accounts = _context.Accounts.ToList();
            return accounts;
        }
        
        public async Task<Account> Save(Account acc) {
            _context.Accounts.Add(acc);
            await _context.SaveChangesAsync();

            return acc;
        }
        
        public async Task<Account> Update(Account acc) {
            _context.Accounts.Update(acc);
            await _context.SaveChangesAsync();


            return acc;
        }
        
        public Account Delete(Account acc) {
            var account = _context.Accounts.FirstOrDefault(c => c.Conta == acc.Conta);
        
            _context.Accounts.Remove(account!);
            _context.SaveChanges();

            return account!;
        }

        public async Task<Account?> Deposit(int accNumber, decimal value)
        {
            var acc = _context.Accounts.FirstOrDefault(c => c.Conta == accNumber);

            if (acc != null)
            {
                acc.Saldo += value;
                await _context.SaveChangesAsync();
                return acc;
            }

            return null;
        }

        public Account? GetByAccountNumber(int accNumber) {
            var account = _context.Accounts.FirstOrDefault(c => c.Conta == accNumber);

            return account;
        }
    }
}