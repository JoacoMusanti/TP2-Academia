using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
   public class EntidadNegocio
    {
       public enum Estados 
      {
        Eliminado,
        Nuevo,
        Modificado,
        NoModificado
      }

      private int _ID;

      public int ID
      {
          get { return _ID; }
          set { _ID = value; }
      }
      private Estados _Estado;

      public Estados Estado
      {
          get { return _Estado; }
          set { _Estado = value; }
      }

      public EntidadNegocio()
      {
          this._Estado = Estados.Nuevo;

      }

    }
}
