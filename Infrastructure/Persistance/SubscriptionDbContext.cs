using Microsoft.EntityFrameworkCore;
using PocMissionPush.Subscriptions;

namespace PocMissionPush.Infrastructure.Persistance;

public class SubscriptionDbContext : DbContext
{
    public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options) : base(options)
    {

    }

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
}