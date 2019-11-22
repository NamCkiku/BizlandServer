namespace Bizland.Domain.Core
{
    public interface IMultiLanguage<T>
    {
        T LanguageId { set; get; }
    }
}