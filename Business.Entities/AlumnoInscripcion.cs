using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    class AlumnoInscripcion : BusinessEntity
    {
        public int Nota {get; set;} 
        public int IdCurso {get; set;}
        public int IdAlumno { get; set; }
        public string Condicion {get; set;}
    }
}
