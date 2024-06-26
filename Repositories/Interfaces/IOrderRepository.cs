using asp.net_mvc.Models;

namespace asp.net_mvc.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void MakeOrder(Order order);
    }
}