using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class docenteCursos: BusinessEntity
    {
        public int id_curso { get; set; }

        public int id_docente {get; set;}
    }
}
