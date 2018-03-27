using POTD.Infrastructure.Interfaces;

namespace POTD.Infrastructure.Models
{
    public abstract class BaseDataModel : IDataModel
    {
        public int Id { get; private set; }
    }
}