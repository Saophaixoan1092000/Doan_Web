using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DAO
{
    public class MenuDao
    {
        SA_Shoes db = null;
        public MenuDao()
        {
            db = new SA_Shoes();
        }

        public List<Menu> ListByGroupID(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status == true).OrderBy(x=>x.DisplayOrder).ToList();
        }
    }
}
