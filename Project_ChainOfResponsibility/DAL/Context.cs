using Microsoft.EntityFrameworkCore;
using Project_ChainOfResponsibility.DAL.Entities;

namespace Project_ChainOfResponsibility.DAL
{
    public class Context:DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0LTDDDI\\SQLEXPRESS01;initial catalog=ChainofResponsibilityDb;integrated security=true");
        }

        public DbSet<BankProcess> BankProcesses { get; set; }
    }
}
