public interface IPushSubscriptionRepository<T>
{
    Task<T> StoreSubscription(T entity);
    Task<List<T>> GetSubscriptions();
    Task<List<T>> GetSubscriptionsByUserId(string userId);
    Task<T> NotifyAll();

}