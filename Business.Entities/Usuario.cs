using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario 
    {
      public string NombreUsuario { get; set; }
      public byte[] Clave { get; set; }
 
      public bool Habilitado { get; set; }
      public int CambiaClave { get; set; }
      
    }
}
