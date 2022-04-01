using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.Common.Interfaces
{
    [FactoryInterface]
    public interface IMeta
    {
        string MetaTitle { get; }
        string MetaDescription { get; }
        string MetaKeywords { get; }
        string MetaDate { get; }
        string MetaVerify { get; }
    }
}
