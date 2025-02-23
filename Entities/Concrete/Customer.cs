using Entities.Abstract;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        // CustomerId type set to string, because NorthwindDB holds CustomerId as string
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
