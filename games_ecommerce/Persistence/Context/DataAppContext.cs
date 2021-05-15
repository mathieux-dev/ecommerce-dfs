using games_ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace games_ecommerce.Persistence.Context
{
    public class DataAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<User> Users { get; set; }
        public DataAppContext(DbContextOptions<DataAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Server=127.0.0.1; port=5432; user id=postgres; password=postgres; database=ecommerce;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(145);
            modelBuilder.Entity<Product>().Property(p => p.Observation).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Product>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>().HasOne(p => p.Publisher).WithMany(p => p.Products)
                .HasForeignKey(p => p.PublisherId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Publisher>().HasKey(p => p.Id);
            modelBuilder.Entity<Publisher>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Publisher>().Property(p => p.CorporativeName).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Publisher>().Property(p => p.PublicName).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<Publisher>().Property(p => p.Cnpj).IsRequired().HasMaxLength(14);
            modelBuilder.Entity<Publisher>().HasMany(p => p.Products).WithOne(p => p.Publisher)
                .HasForeignKey(p => p.PublisherId);

            modelBuilder.Entity<Purchase>().ToTable("Purchases");
            modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
            modelBuilder.Entity<Purchase>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Purchase>().Property(p => p.Date).ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Purchase>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Adress).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Purchase>().Property(p => p.PostalCode).IsRequired().HasMaxLength(8);
            modelBuilder.Entity<Purchase>().Property(p => p.Observation).HasMaxLength(255);
            modelBuilder.Entity<Purchase>().Property(p => p.PurchaseStatus).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.PaymentFormat).IsRequired();
            modelBuilder.Entity<Purchase>().HasOne(p => p.User).WithMany(p => p.Purchases).HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Purchase>().HasMany(p => p.Products).WithOne(p => p.Purchase)
                .HasForeignKey(p => p.PurchaseId);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<User>().Property(p => p.Cpf).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(45);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<User>().HasMany(p => p.Purchases).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        }
    }
}
