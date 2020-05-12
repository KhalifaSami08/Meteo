using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    public class Watchdog
    {
        public int id;
        public object type_Measure;
        public object format;

        public Watchdog(int id, object type_Measure, object format)
        {
            this.id = id;
            this.type_Measure = type_Measure;
            this.format = format;
        }




    }
}
