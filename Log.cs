using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteo
{

    /**
     * 
     * CODE EXAMEN COLLECTION MODEL DEBUT
     * 
     */
    class Log
    {

        public int logRef;
        public String logDate;
        public String logType;
        public String logDescription;

        //lire
        public Log(int logRef, string logDate, string logType, string logDescription)
        {
            this.logRef = logRef;
            this.logDate = logDate;
            this.logType = logType;
            this.logDescription = logDescription;
        }

        //ecrire
        public Log(string logType, string logDescription)
        {
            this.logDate = DateTime.Now.ToString();
            this.logType = logType;
            this.logDescription = logDescription;
        }
    }

    /**
     * 
     * CODE EXAMEN COLLECTION MODEL FIN
     * 
     */
}
