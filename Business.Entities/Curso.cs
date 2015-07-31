using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Curso : BusinessEntity
    {
        public int IdCurso { get; set; }
        public int IdMateria { get; set; }
        public int IdComision { get; set; }
        public int AnioCalendario { get; set; }
        public int Cupo { get; set; }
    }
}
