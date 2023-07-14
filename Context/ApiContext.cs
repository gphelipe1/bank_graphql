using Bank.Model;
using Microsoft.EntityFrameworkCore;

namespace Bank.Context
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){}

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            
            builder.Entity<Account>(entity => {
                entity.HasIndex(e => e.Conta).IsUnique();
            });

            builder.Entity<Account>(entity => {
                entity.HasData(new Account{
                    Id=1,
                    Conta = "54321",
                    Saldo = 160,

                });
            });
        }
    }
}   