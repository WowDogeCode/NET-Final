using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public List<Order> GetAllOrders()
        {
            return _orderDal.GetAll();
        }

        public Order GetById(int OrderId)
        {
            return _orderDal.Get(x => x.OrderId == 10);
        }
    }
}
