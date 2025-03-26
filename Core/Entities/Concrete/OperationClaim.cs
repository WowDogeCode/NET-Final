namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
