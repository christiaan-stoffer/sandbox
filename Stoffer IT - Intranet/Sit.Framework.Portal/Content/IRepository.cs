namespace Sit.Framework.Portal.Content
{
    public interface IRepository<TItem>
        where TItem : IEntity
    {
        int Create(TItem item);

        void Update(int key, TItem before, TItem after);

        void Delete(int key);

        TItem Get(int key);
    }
}