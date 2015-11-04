using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class InscripcionAlumnoAdapter: Adapter
    {
        protected SqlDataAdapter _daInscripcionAlumno;

        public List<AlumnoInscripcion> GetAll(int id)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                OpenConnection();

                SqlCommand comInscripciones = new SqlCommand("select * from dbo.alumnos_inscripciones where id_alumno = @id and baja_logica = 0",SqlCon);
                comInscripciones.Parameters.AddWithValue("@id",id);
                SqlDataReader drInscripcionesAlumno = comInscripciones.ExecuteReader();

                while(drInscripcionesAlumno.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();
                    ins.ID = (int)drInscripcionesAlumno["id_inscripcion"];
                    ins.IdAlumno = (int)drInscripcionesAlumno["id_alumno"];
                    ins.IdCurso = (int)drInscripcionesAlumno["id_curso"];
                    ins.Nota = (int)drInscripcionesAlumno["nota"];
                    ins.Condicion= (string)drInscripcionesAlumno["condicion"];
                    ins.Baja = (bool)drInscripcionesAlumno["baja_logica"];

                    inscripciones.Add(ins);
                }
                 drInscripcionesAlumno.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar las inscripciones de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }
            return inscripciones;
         }
    }
}
