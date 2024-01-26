using KT_DMAWS.DBContext;
using KT_DMAWS.Interfaces;
using KT_DMAWS.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace KT_DMAWS.Repository
{
    public class OrderRepository : IOrderInterfaces
    {
        private readonly KT_DMAWSDBContext _dbcontex;
        public OrderRepository(KT_DMAWSDBContext dbcontex)
        {
            _dbcontex = dbcontex;
        }

        public ICollection<Order> CreateOrder()
        {
            return _dbcontex.Orders.OrderBy(o => o.Id).ToList();
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                _dbcontex.Orders.Add(order);
                _dbcontex.SaveChanges();
                return order;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error creating order: {ex.Message}");
                return null;
            }
        }

        public bool DeleteOrder(int Id)
        {
            var delete = _dbcontex.Orders.Find(Id);
            if(delete != null)
            {
                return false;
            }
            _dbcontex.Orders.Remove(delete);
            _dbcontex.SaveChanges();
            return true;
        }

        public Order GetOrder(int Id)
        {
            return _dbcontex.Orders.Where(x => x.Id == Id).FirstOrDefault();
            
        }

        public Order UpdateOrder(int Id, Order updatedOrder)
        {
            var update = _dbcontex.Orders.Find(Id);
            if(update != null)
            {
                update.ShipAddress = updatedOrder.ShipAddress;
                update.DeliveryTime = updatedOrder.DeliveryTime;
            }
            else
            {
                return null;
            }
            _dbcontex.SaveChanges();
            return update;
        }
    }
}
