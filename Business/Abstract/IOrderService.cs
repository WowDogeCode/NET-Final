using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetById(int OrderId);
    }
}
