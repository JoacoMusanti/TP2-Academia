using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        public int IdEspecialidad { get; set; }
        public string Descripcion { get; set; }
    }
}
