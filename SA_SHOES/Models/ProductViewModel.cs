using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_SHOES.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public long ID { set; get; }
        public String Images { set; get; }
        public String Name { set; get; }
        public decimal? Price { set; get; }
        public String CateName { set; get; }
        public String CateMetaTitle { set; get; }
        public String Metatitle { set; get; }
        public DateTime CreatedDate { set; get; }

    }
}