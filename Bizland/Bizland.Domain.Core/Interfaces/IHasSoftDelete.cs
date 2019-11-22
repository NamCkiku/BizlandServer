namespace Bizland.Domain.Core
{
    public interface IHasSoftDelete
    {
        bool IsDeleted { set; get; }
    }
}