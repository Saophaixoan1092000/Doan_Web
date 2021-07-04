using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DAO
{
    public class ProductDao
    {
        SA_Shoes db = null;
        public ProductDao()
        {
            db = new SA_Shoes();
        }
        //Lấy danh sách sản phẩm mới
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x=> x.CreateDate).Take(top).ToList();
        }
        
        //Lấy danh sách sản phẩm theo danh mục
        public List<Product> ListByCategoryID(long categoryID, ref int totalRecord, int pageIndex =1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(p => p.CreateDate).Skip((pageIndex - 1)*pageSize).ToList();
            return model;
        }

        public List<Product> ListProduct(ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Count();
            var model = db.Products.OrderByDescending(p => p.CreateDate).Skip((pageIndex - 1) * pageSize).ToList();
            return model;
        }
        //Lấy danh sách sản phẩm top
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x=> x.TopHot != null && x.TopHot > x.CreateDate).OrderByDescending(x => x.CreateDate).ToList();
        }

        public List<Product> ListRelatedProduct(long productID)
        {
            var product = db.Products.Find(productID);
            return db.Products.Where(x => x.ID != productID && x.CategoryID == product.CategoryID ).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }

      
    }
}
