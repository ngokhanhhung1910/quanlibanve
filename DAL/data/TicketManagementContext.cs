using System.Data.Entity;
using DAL.Entities;

namespace DAL.Data
{
    public class TicketManagementContext : DbContext
    {
        public TicketManagementContext() : base("name=TicketManagementContext")
        {
        }

        // DbSet for User table
        public DbSet<User> Users { get; set; }
    }
}