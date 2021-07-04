using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.DAO
{
    public class UserDao
    {
        SA_Shoes db = null;
        public UserDao()
        {
            db = new SA_Shoes();
        }

        public long Insert(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return us.ID;
        }

        public int login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.username == userName);
            if(result == null)
            {
                return 0;
            }
            else 
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.username == userName) ;
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        public bool checkUsername(String userName)
        {
            return db.Users.Count(x => x.username == userName) > 0;
        }

        public bool checkEmail(String email)
        {
            return db.Users.Count(x => x.email == email) > 0;
        }
    } 
}
