using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DAO
{
    public class ProductCategoryDao
    {
        SA_Shoes db = null;
        public ProductCategoryDao()
        {
            db = new SA_Shoes();
        }

        public List<ProductCategory> ListAll() {
            {
                return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
             }
        }
        public List<ProductCategory> ListAll1(int top)
        {
            return db.ProductCategories.Where(x=> x.Status == true).Take(top).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        
    }
}
