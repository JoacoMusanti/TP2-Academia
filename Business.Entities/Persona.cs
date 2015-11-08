using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Business.Entities
{
    
    [DataContract]
   public class Persona : BusinessEntity
    {
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public DateTime FechaNacimiento { get; set; }
        [DataMember]
        public int IdPlan { get; set; }
        [DataMember]
        public int Legajo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public TipoPersonas TipoPersona { get; set; }

        // Datos previamente del usuario ahora en persona
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public byte[] Clave { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }
        [DataMember]
        public int CambiaClave { get; set; }
        public enum TipoPersonas
        {
            Administrativo,
            Docente,
            Alumno
        }
        
    }
}
