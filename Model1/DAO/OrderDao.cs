using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model1.EF;

namespace Model1.DAO
{
    public class OrderDao
    {
        SA_Shoes db = null;
        public OrderDao()
        {
            db = new SA_Shoes();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}
