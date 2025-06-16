using Microsoft.EntityFrameworkCore;
using PocMissionPush.Models;

public class SubscriptionRepository : IPushSubscriptionRepository<Subscription>
{
    private readonly SubscriptionContext _context;
    public SubscriptionRepository(SubscriptionContext context)
    {
        _context = context;
    }

    public async Task<Subscription> StoreSubscription(Subscription entity)
    {
        _context.Subscriptions.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public Task<Subscription> NotifyAll()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Subscription>> GetSubscriptions()
    {
        return await _context.Subscriptions.ToListAsync();
    }

    public async Task<List<Subscription>> GetSubscriptionsByUserId(string userId)
    {
        return await _context.Subscriptions.Where(sub => sub.UserId == userId).ToListAsync();
    }
}