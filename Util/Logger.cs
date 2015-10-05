using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Logger
    {
        private static string pathArchivo = "D:/log.txt";

        public static bool LogHabilitado
        {
            get;
            set;
        }

        public static void Log(Exception ex)
        {
            if (LogHabilitado)
            {
                using (StreamWriter sw = new StreamWriter(pathArchivo, true))
                {
                    sw.WriteLine("Fecha:       " + DateTime.Today.Date.ToShortDateString());
                    sw.WriteLine("Hora:        " + DateTime.Now.TimeOfDay.ToString());
                    sw.WriteLine("Fuente:      " + ex.Source.ToString());
                    sw.WriteLine("Metodo:      " + ex.TargetSite.ToString());
                    sw.WriteLine("Error:       " + ex.Message);
                    sw.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            
        }
    }
}
