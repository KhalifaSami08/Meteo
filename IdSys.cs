using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    public class IdSys : Watchdog
    {
        public String source;
        public String detail;
        public String status;
        
        public IdSys(int id,object type_Measure, object format, string source, string detail, string status) : base(id, type_Measure, format)
        {
            this.source = source;
            this.detail = detail;
            this.status = status;
        }

        public static object[] getTypeMeasure()
        {
            object[] TypeAvailable = { "ID_SYSTEM","WATCHLOG" };
            return TypeAvailable;
        }
    }
}
