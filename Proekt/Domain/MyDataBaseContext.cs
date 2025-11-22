
using Microsoft.EntityFrameworkCore;
using Proekt.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt.Domain
{
    public class MyDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyDatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PeshkovaEA;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Настраиваем ограничение UNIQUE (создаем индекс)
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            //Настраиваем начальные данные
            modelBuilder.Entity<User>().HasData([
                new User(1, "vasily", "1234566890", "my bio", 100),
                new User(2, "uniquelogin", "5675674747", "my biomy biomy bio", 55),
                new User(3, "lshfdsf", "1235889870", "no info.", 10),
                new User(4, "deadlyparkourkiller", "6876901233", "", -9999),
                new User(5, "darkbrawlstarsassassin", "8978970754", "my biomy bio", 876),
                new User(6, "miha98", "1465848658", "my biomy biomy bio", 123)
                ]);
        }
    }
}
