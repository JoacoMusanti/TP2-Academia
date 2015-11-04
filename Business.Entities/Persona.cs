using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    

   public class Persona : BusinessEntity
    {
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPlan { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public TipoPersonas TipoPersona { get; set; }

        // Datos previamente del usuario ahora en persona
        public string NombreUsuario { get; set; }
        public byte[] Clave { get; set; }
        public bool Habilitado { get; set; }
        public int CambiaClave { get; set; }
        public enum TipoPersonas
        {
            Administrativo,
            Docente,
            Alumno
        }
        
    }
}
