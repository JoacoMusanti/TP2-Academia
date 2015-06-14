using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    class Materia : BusinessEntity
    {
        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int HorasSemanales { get; set; }
        public int HorasTotales { get; set; }
        public int IdPlan { get; set; }
    }
}
