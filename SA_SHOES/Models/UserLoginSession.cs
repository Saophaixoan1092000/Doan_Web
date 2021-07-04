using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_SHOES.Models
{
    [Serializable]
    public class UserLoginSession
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
    }
}