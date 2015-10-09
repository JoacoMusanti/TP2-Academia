using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        protected SqlDataAdapter _daCursos;

        /// <summary>
        /// Devuelve una lista con todos los cursos
        /// </summary>
        /// <returns></returns>
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                OpenConnection();

                SqlCommand comCurso = new SqlCommand("select * from dbo.cursos where baja_logica = 0", SqlCon);

                SqlDataReader drCursos = comCurso.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso cur = new Curso();

                    cur.ID = (int)drCursos["id_curso"];
                    cur.IdMateria = (int)drCursos["id_materia"];
                    cur.IdComision = (int)drCursos["id_comision"];
                    cur.Cupo = (int)drCursos["cupo"];
                    cur.AnioCalendario = (int)drCursos["anio_calendario"];
                    cur.Baja = (bool)drCursos["baja_logica"];

                    cursos.Add(cur);
                }

                drCursos.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar los cursos de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return cursos;
        }

        /// <summary>
        /// Devuelve el curso que tenga la id indicada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Curso GetOne(int id)
        {
            Curso cur = new Curso();

            try
            {
                OpenConnection();

                SqlCommand curCurso = new SqlCommand("select * from dbo.cursos where @id = id_curso and baja_logica = 0", SqlCon);

                curCurso.Parameters.AddWithValue("@id", id);

                SqlDataReader drCurso = curCurso.ExecuteReader();

                if (drCurso.Read())
                {
                    cur.ID = (int)drCurso["id_curso"];
                    cur.IdMateria = (int)drCurso["id_materia"];
                    cur.IdComision = (int)drCurso["id_comision"];
                    cur.Cupo = (int)drCurso["cupo"];
                    cur.AnioCalendario = (int)drCurso["anio_calendario"];
                    cur.Baja = (bool)drCurso["baja_logica"];

                drCurso.Close();
            }}
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar el curso de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return cur;
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                SqlCommand comDelete = new SqlCommand("delete dbo.cursos where id_curso = @id", SqlCon);

                comDelete.Parameters.AddWithValue("@id", id);

                comDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar el curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Curso curs)
        {
            try
            {
                OpenConnection();

                SqlCommand cursInsert = new SqlCommand("insert into dbo.cursos(id_materia, id_comision, anio_calendario, cupo, baja_logica) " +
                    " values (@materia, @comision, @anio,@cupo, @baja_logica) select @@identity", SqlCon);

                cursInsert.Parameters.AddWithValue("@materia", curs.IdMateria);
                cursInsert.Parameters.AddWithValue("@comision", curs.IdComision);
                cursInsert.Parameters.AddWithValue("@anio", curs.AnioCalendario);
                cursInsert.Parameters.AddWithValue("@cupo", curs.Cupo);
                cursInsert.Parameters.AddWithValue("@baja_logica", curs.Baja);

                curs.ID = decimal.ToInt32((decimal)cursInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar el curso en la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Curso cur)
        {
            try
            {
                OpenConnection();

                SqlCommand curUpdate = new SqlCommand("update dbo.cursos set id_materia = @materia, id_comision = @comision ,anio_calendario = @anio, " +
                    " cupo = @cupo ,baja_logica = @baja_logica where id_curso = @id and baja_logica = 0", SqlCon);

                curUpdate.Parameters.AddWithValue("@materia", cur.IdMateria);
                curUpdate.Parameters.AddWithValue("@comision", cur.IdComision);
                curUpdate.Parameters.AddWithValue("@anio", cur.AnioCalendario);
                curUpdate.Parameters.AddWithValue("@cupo", cur.Cupo);
                curUpdate.Parameters.AddWithValue("@baja_logica", cur.Baja);
                curUpdate.Parameters.AddWithValue("@id", cur.ID);

                curUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar los datos del curso", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                Update(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                Delete(curso.ID);
            }

            curso.State = BusinessEntity.States.Unmodified;
        }

    }
}
