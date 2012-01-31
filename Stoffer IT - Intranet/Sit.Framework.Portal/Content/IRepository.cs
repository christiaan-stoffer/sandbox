namespace Sit.Framework.Portal.Content
{
    public interface IRepository<TItem, TKey>
        where TItem : IEntity<TKey>
    {
        TKey Create(TItem item);

        void Update(TKey key, TItem before, TItem after);

        void Delete(TKey key);

        TItem Get(TKey key);
    }
}