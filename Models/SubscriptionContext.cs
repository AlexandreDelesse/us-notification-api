using Microsoft.EntityFrameworkCore;

namespace PocMissionPush.Models;

public class SubscriptionContext : DbContext
{
    public SubscriptionContext(DbContextOptions<SubscriptionContext> options) : base(options)
    {

    }

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
}