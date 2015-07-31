using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    
    class DocenteCurso : BusinessEntity
    {
        public int IdCurso { get; set; }
        public int IdDocente { get; set; }

        public TiposCargos TipoCargo { get; set; }

        public enum TiposCargos
        {
            Titular,
            Auxiliar,
            Suplente,
            Adscripto

        }
    }
}
