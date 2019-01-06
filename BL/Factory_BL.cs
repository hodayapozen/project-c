using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Factory_BL
    {

        private static IBL bl = null;

        public static IBL GetBL()
        {
            if ( bl==null)
            {
                bl = new BL_imp();
            }
            return bl;


        }
    }
}
