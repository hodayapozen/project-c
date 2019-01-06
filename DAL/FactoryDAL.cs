using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FactoryDAL
    {
        private static Dal_imp dal = null;

        public static Idal GetDAL()
        {
            if (null == dal)
            {
                dal = new Dal_imp();
            }
            return dal;
        }
        //public static Idal getDAL()
        //{
        //    return new Dal_imp();
        //}
    }
}
