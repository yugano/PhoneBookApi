using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Database
{
    public class PhoneBookDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=78.188.194.67;Initial Catalog=KRKHoldingDB;Persist Security Info=True;User ID=sa;Password=!1qazwsx");
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-PMG4MRHL\SQLEXPRESS;Database=PhoneBook;Trusted_Connection=True;Integrated Security=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
