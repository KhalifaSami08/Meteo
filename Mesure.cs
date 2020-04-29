using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    public class Mesure
    {
        public int ID_Measure;
        public object type_Measure;
        public object format;
        public int minValue;
        public int maxValue;
        public List<String> data { get; set; }

        public Mesure(int ID_Measure, object type_Measure, object format, int minValue, int maxValue)
        {
            this.ID_Measure = ID_Measure;
            this.type_Measure = type_Measure;
            this.format = format;
            this.minValue = minValue;
            this.maxValue = maxValue;
            data = new List<String>();
        }

        public static object[] getFormatDispo()
        {
            object[] formatsAvailable = { "8", "16", "24", "32" };
            return formatsAvailable;
        }

        public static object[] getTypeMeasure()
        {
            object[] TypeAvailable = { "TEMPERATURE(C°)", "HUMIDITY(%)", "ATMOSPHERIC_PRESSURE(Pa)", "WIND_SPEED(m/s)" };
            return TypeAvailable;
        }

    }
}
