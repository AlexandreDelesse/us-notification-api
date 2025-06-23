


using Microsoft.EntityFrameworkCore;
using PocMissionPush.Infrastructure.Persistance;
using PocMissionPush.Subscriptions;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly SubscriptionDbContext _context;
    public SubscriptionRepository(SubscriptionDbContext context)
    {
        _context = context;
    }

    public async Task<Subscription> CreateSubscription(Subscription sub)
    {
        Subscription createdSub = _context.Subscriptions.Add(sub).Entity;
        await _context.SaveChangesAsync();
        return createdSub;
    }

    public async Task DeleteSubscription(Subscription sub)
    {
        _context.Remove(sub);
        await _context.SaveChangesAsync();

    }

    public async Task<List<Subscription>> GetSubscriptionByUserIds(List<string> userIds)
    {
        return await _context.Subscriptions.Where(sub => userIds.Contains(sub.UserId))
        .GroupBy(sub => sub.UserId)
        .Select(g => g.OrderByDescending(s => s.LastUsed).First())
        .ToListAsync();
    }



    public async Task<Subscription?> GetSubscriptionsByEndPoint(string endpoint)
    {
        return await _context.Subscriptions.FirstOrDefaultAsync(sub => sub.Endpoint == endpoint);
    }

    public Task<List<Subscription>> GetSubscriptionsByUserId(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Subscription>> GetSubscriptionsByUserId(List<string> userId)
    {
        throw new NotImplementedException();
    }

    public Task<Subscription> UpdateSubscription(Subscription newSub)
    {
        throw new NotImplementedException();
    }
}