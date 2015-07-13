using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        private List<Plan> _planes = new List<Plan>(); 

        public string Descripcion { get; set; }
    }
}
