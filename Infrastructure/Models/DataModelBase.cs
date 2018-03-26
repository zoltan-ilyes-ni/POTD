using PTD.Infrastructure.Interfaces;

namespace PTD.Infrastructure.Models
{
    public abstract class DataModelBase : IDataModel
    {
        public int Id { get; private set; }
    }
}