namespace POTD.DataService.Models
{
    public abstract class ModelBase
    {
        public ModelBase(int id)
        {
            Id = id;
        }

        // making sure ID's are not changed after instancee
        public int Id { get; protected set; }
    }
}