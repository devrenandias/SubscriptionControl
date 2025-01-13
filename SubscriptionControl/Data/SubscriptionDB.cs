using Microsoft.EntityFrameworkCore;
using SubscriptionControl.Models;

namespace SubscriptionControl.Data
{
    public class SubscriptionDB : DbContext
    {
        public SubscriptionDB(DbContextOptions<SubscriptionDB> options)
            : base(options) { }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
