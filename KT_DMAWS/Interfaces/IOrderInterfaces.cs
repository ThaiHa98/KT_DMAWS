using KT_DMAWS.Model;

namespace KT_DMAWS.Interfaces
{
    public interface IOrderInterfaces
    {
        ICollection<Order> CreateOrder();
        Order CreateOrder(Order order);
        Order UpdateOrder(int Id, Order updatedOrder);
        bool DeleteOrder(int Id);
        Order GetOrder(int Id);

    }
}
