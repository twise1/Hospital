using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Project_1._0
{
    class Perexod
    {
        private static DataTable DT;
        
        public static void prinal(DataTable D)
        {
            DT = D;
        }
        public static DataTable vernul() 
        {
            return (DT);
        }
    }
}
