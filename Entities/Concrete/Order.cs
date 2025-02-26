using Core.Entities;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; } // CustomerId type set to string, because NorthwindDB holds CustomerId as string
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
