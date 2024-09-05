using LeageBillete_api.Model.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeageBillete_api.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options)
        { }

        public DbSet<Ticket_purchase> Ticket_purchases { get; set;}
        public DbSet<Event_leage> Event_leages { get; set;}
        public DbSet<Price_ticket> Price_Tickets { get; set;}
        public DbSet<Detail_purchase> Detail_Purchases { get; set;}
        public DbSet<Event_day> Event_Days { get; set;}

    
    }
}
