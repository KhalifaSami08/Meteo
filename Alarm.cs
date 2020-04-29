using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{
    class Alarm
    {
        public int id_Alarme;
        public String type_mesure;

        public int minAlarm;
        public int maxAlarm;

        public Alarm(int id_Alarme, string type_mesure, int minAlarm, int maxAlarm)
        {
            this.id_Alarme = id_Alarme;
            this.type_mesure = type_mesure;
            this.minAlarm = minAlarm;
            this.maxAlarm = maxAlarm;
        }
    }
}
