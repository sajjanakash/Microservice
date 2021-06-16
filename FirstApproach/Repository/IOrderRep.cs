using FirstApproach.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApproach.Repository
{
  public   interface IOrderRep
    {
       List<Order> GetOrders();
        //Product GetProductById(int ProductId);
        void InsertOrder(Order order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(Order order);
        void Save();
       Order GetOrdertByID(int id);
    }
}
