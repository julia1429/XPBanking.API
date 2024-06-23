using Microsoft.EntityFrameworkCore;
using System.Transactions;
using XPBanking.API.Services.Dto;

namespace XPBanking.API.Data
{
    public class XPBankingContext : DbContext 
    {
        public XPBankingContext(DbContextOptions<XPBankingContext> options)
            : base(options)
        {
            if (Database.IsSqlServer())
                Database.SetCommandTimeout(9000);
                    
        }

        public DbSet<UserTransaction> UserTransaction { get; set; }  
        public DbSet<InvestmentDto> investmentDto { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<TransactionDto> transactionDto { get; set; }
        public DbSet<UserStatement> userStatements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTransaction>(entity =>
            {
            entity.ToView("UserTransaction");
            entity.HasNoKey();
            });

            modelBuilder.Entity<InvestmentDto>().ToTable("InvestmentDto");
            modelBuilder.Entity<InvestmentDto>().HasKey(e => e.Id);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().HasKey(o => o.id);

            modelBuilder.Entity<TransactionDto>().ToTable("TransactionDto");
            modelBuilder.Entity<TransactionDto>().HasKey(u => u.Id);

            modelBuilder.Entity<UserStatement>(entity =>
            {
                entity.ToView("UserStatement");
                entity.HasNoKey();
            });

        }

    }
}
