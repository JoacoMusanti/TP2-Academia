using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
  public  class Usuario : EntidadNegocio
    {
      string NombreUsuario { get; set; }
      string Clave { get; set; }
      string Nombre { get; set; }
      string Apellido { get; set; }
      string Email { get; set; }
      bool Habilitado { get; set; }
      // comentario
      
    }
}
