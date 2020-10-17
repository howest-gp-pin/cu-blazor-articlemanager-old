namespace ArticleManager.Core.Entities.Base
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
