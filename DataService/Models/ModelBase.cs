namespace POTD.DataService.Models
{
    public abstract class ModelBase
    {
        // making sure ID's are not changed after instancee
        public int Id { get; protected set; }

        public ModelBase(int id)
        {
            Id = id;
        }
    }
}