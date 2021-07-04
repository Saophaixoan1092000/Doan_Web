using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DAO
{
    public class OrderDetailDao
    {
        SA_Shoes db = null;
        public OrderDetailDao()
        {
            db = new SA_Shoes();
        }
        public bool Insert(OrdersDetail detail)
        {
            try
            {
                db.OrdersDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
