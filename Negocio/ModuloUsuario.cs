using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class ModuloUsuario : EntidadNegocio
    {
        int IdUsuario { get; set;} 
        int IdModulo { get; set;} 
        bool PermiteAlta { get; set;} 
        bool PermiteBaja { get; set;}
        bool PermiteModificacion { get; set;} 
        bool PermiteConsulta { get; set;} 
   }
}
