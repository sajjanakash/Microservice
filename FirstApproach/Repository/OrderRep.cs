using FirstApproach.ContextDB;
using FirstApproach.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApproach.Repository
{
    public class OrderRep : IOrderRep
    {
        private readonly OrderDBContext _dbContext;
        public OrderRep(OrderDBContext dbContext)
        {
            //_dbproduct = product;
            _dbContext = dbContext;
        }

        public void DeleteOrder(int OrderId)
        {
            var product = _dbContext.orders.Find(OrderId);
            _dbContext.orders.Remove(product);
            Save();
        }

      

        public List<Order> GetOrders()
        {
            return _dbContext.orders.ToList();
        }

        public Order GetOrdertByID(int id)
        {
            return _dbContext.orders.Find(id);
        }

        public void InsertOrder(Order order)
        {
            _dbContext.Add(order);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            Save();
        }
    }
}
