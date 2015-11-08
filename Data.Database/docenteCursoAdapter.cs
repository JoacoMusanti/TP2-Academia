using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class docenteCursoAdapter: Adapter
    {
        protected SqlDataAdapter _daDocenteCurso;
        public List<docenteCursos> GetAll(int id)
        {
            List<docenteCursos> docentecursos = new List<docenteCursos>();

            try
            {
                OpenConnection();

                SqlCommand comDocenteCurso = new SqlCommand("select * from dbo.docentes_cursos where id_docente=@id and baja_logica = 0", SqlCon);
                comDocenteCurso.Parameters.AddWithValue("@id", id);
                SqlDataReader drDocenteCurso = comDocenteCurso.ExecuteReader();

                while (drDocenteCurso.Read())
                {
                    docenteCursos docur = new docenteCursos();

                    docur.ID = (int)drDocenteCurso["id_dictado"];
                    docur.id_curso = (int)drDocenteCurso["id_curso"]; ;
                    docur.id_docente = (int)drDocenteCurso["id_docente"];
                    docur.Baja = (bool)drDocenteCurso["baja_logica"];

                    docentecursos.Add(docur);
                }
                drDocenteCurso.Close();
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
            return docentecursos;
        }

        public docenteCursos GetOne(int id)
        {
            docenteCursos docur = new docenteCursos();

            try
            {
                OpenConnection();

                SqlCommand comDocenteCurso = new SqlCommand("select * from dbo.docentes_cursos where id_dictado = @id and baja_logica = 0", SqlCon);

                comDocenteCurso.Parameters.AddWithValue("@id", id);

                SqlDataReader drDocenteCurso = comDocenteCurso.ExecuteReader();

                if (drDocenteCurso.Read())
                {
                    docur.ID = (int)drDocenteCurso["id_dictado"];
                    docur.id_curso = (int)drDocenteCurso["id_curso"]; ;
                    docur.id_docente = (int)drDocenteCurso["id_docente"];
                    docur.Baja = (bool)drDocenteCurso["baja_logica"];
                }

                drDocenteCurso.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar el curso de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return docur;
        }
    }
}
