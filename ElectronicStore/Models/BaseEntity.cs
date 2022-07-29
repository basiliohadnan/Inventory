namespace ElectronicStore.Models
{
    public abstract class BaseEntity
    {
        public static int Id { get; protected set; }
        public int Code { get; protected set; }
        public static void IncrementIdentifier() => Id++; 
    }
}
