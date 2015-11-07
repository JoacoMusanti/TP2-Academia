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

                SqlCommand comInscripciones = new SqlCommand("select * from dbo.alumnos_inscripciones where id_alumno=@id and baja_logica = 0",SqlCon);
                comInscripciones.Parameters.AddWithValue("@id",id);
                SqlDataReader drInscripcionesAlumno = comInscripciones.ExecuteReader();

                while(drInscripcionesAlumno.Read())
                {
                    AlumnoInscripcion ins = new AlumnoInscripcion();

                    ins.ID = (int)drInscripcionesAlumno["id_inscripcion"];
                    ins.IdAlumno = (int)drInscripcionesAlumno["id_alumno"];
                    ins.IdCurso = (int)drInscripcionesAlumno["id_curso"];
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

        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion ins = new AlumnoInscripcion();

            try
            {
                OpenConnection();

                SqlCommand comInscripcion = new SqlCommand("select * from dbo.alumnos_inscripciones where @id = id_inscripcion and baja_logica = 0", SqlCon);

                comInscripcion.Parameters.AddWithValue("@id", id);

                SqlDataReader drInscripcionesAlumno = comInscripcion.ExecuteReader();

                if (drInscripcionesAlumno.Read())
                {
                    ins.ID = (int)drInscripcionesAlumno["id_inscripcion"];
                    ins.IdAlumno = (int)drInscripcionesAlumno["id_alumno"];
                    ins.IdCurso = (int)drInscripcionesAlumno["id_curso"];
                    ins.Condicion = (string)drInscripcionesAlumno["condicion"];
                    ins.Baja = (bool)drInscripcionesAlumno["baja_logica"];
                }

                drInscripcionesAlumno.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar la inscripcion de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return ins;
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                SqlCommand comDelete = new SqlCommand("delete dbo.alumnos_inscripciones where id_inscripcion = @id", SqlCon);

                comDelete.Parameters.AddWithValue("@id", id);

                comDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar la inscripcion", e);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void Update(AlumnoInscripcion aluIns)
        {
            try
            {
                OpenConnection();

                SqlCommand comUpdate = new SqlCommand("update dbo.alumnos_inscripciones set id_alumno = @id_alumno,id_curso=@id_curso, condicion=@condicion,baja_logica = @baja_logica where id_inscripcion = @id_inscripcion and baja_logica = 0", SqlCon);

                comUpdate.Parameters.AddWithValue("@id_inscripcion",aluIns.ID);
                comUpdate.Parameters.AddWithValue("@id_alumno", aluIns.IdAlumno);
                comUpdate.Parameters.AddWithValue("@id_curso", aluIns.IdCurso);
                comUpdate.Parameters.AddWithValue("@condicion", aluIns.Condicion);
                comUpdate.Parameters.AddWithValue("@baja_logica", aluIns.Baja);

                comUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar los datos de la inscripcion", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(AlumnoInscripcion aluIns)
        {
            try
            {
                OpenConnection();

                SqlCommand comInsert = new SqlCommand("insert into dbo.alumnos_inscripciones (id_alumno,id_curso,condicion,baja_logica) " +
                    "values (@id_alumno,@id_curso, @condicion,@baja_logica)select @@identity", SqlCon);

                comInsert.Parameters.AddWithValue("@id_alumno", aluIns.IdAlumno);
                comInsert.Parameters.AddWithValue("@id_curso", aluIns.IdCurso);
                comInsert.Parameters.AddWithValue("@condicion", aluIns.Condicion);
                comInsert.Parameters.AddWithValue("@baja_logica", aluIns.Baja);

                aluIns.ID = decimal.ToInt32((decimal)comInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar la inscripcion en la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        
        public void Save(AlumnoInscripcion inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.New)
            {
                Insert(inscripcion);
            }
            if (inscripcion.State == BusinessEntity.States.Modified)
            {
                Update(inscripcion);
            }

            else if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                Delete(inscripcion.ID);
            }

            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}
