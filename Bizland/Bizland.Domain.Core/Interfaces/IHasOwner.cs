namespace Bizland.Domain.Core
{
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}