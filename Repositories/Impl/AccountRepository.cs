using Bank.Context;
using Bank.Model;

namespace Bank.Repositories
{
    public class AccountRepository: IAccountRepository
    {
        private readonly ApiContext _context;
        public AccountRepository(ApiContext context) {
            _context = context;
        }

        public List<Account> GetAll() {
            var accounts = _context.Accounts.ToList();
            return accounts;
        }
        
        public Account Save(Account acc) {
            _context.Accounts.Add(acc);
            _context.SaveChangesAsync();

            return acc;
        }
        
        public Account Update(Account acc) {
            _context.Accounts.Update(acc);
            _context.SaveChanges();

            return acc;
        }
        
        public Account Delete(Account acc) {
            var account = _context.Accounts.FirstOrDefault(c => c.Conta == acc.Conta);
        
            _context.Accounts.Remove(account!);
            _context.SaveChanges();

            return account!;
        }

        public Account? Deposit(int accNumber, decimal value) {
            var acc = _context.Accounts.Where(c => c.Conta == accNumber).FirstOrDefault();

            if (acc != null) {
                acc.Saldo += value;
                _context.Accounts.Update(acc);
                _context.SaveChanges();

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