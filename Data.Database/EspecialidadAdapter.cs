using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    class EspecialidadAdapter : Adapter
    {
        protected SqlDataAdapter _daEspecialidades;

        /// <summary>
        /// Devuelve una lista con todos las especialidades
        /// </summary>
        /// <returns></returns>
        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                this.OpenConnection();

                SqlCommand comEspecialidades = new SqlCommand("select * from especialidades", SqlCon);

                SqlDataReader drEspecialidades = comEspecialidades.ExecuteReader();

                while (drEspecialidades.Read())
                {
                    Especialidad esp = new Especialidad();

                    esp.ID = (int) drEspecialidades["id_especialidad"];
                    esp.Descripcion = (string) drEspecialidades["desc_especialidad"];

                    especialidades.Add(esp);
                }

                drEspecialidades.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar recuperar las especialidades de la base de datos", e);
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }

        /// <summary>
        /// Devuelve la especialidad que tenga la id indicada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Especialidad GetOne(int id)
        {
            Especialidad esp = new Especialidad();

            try
            {
                this.OpenConnection();

                SqlCommand comEspecialidad = new SqlCommand("select * from especialidades where id_especialidad = @id",
                    SqlCon);
                comEspecialidad.Parameters.AddWithValue("@id", id);

                SqlDataReader drEspecialidad = comEspecialidad.ExecuteReader();

                if (drEspecialidad.Read())
                {
                    esp.ID = (int) drEspecialidad["id_especialidad"];
                    esp.Descripcion = (string) drEspecialidad["desc_especialidad"];
                }

                drEspecialidad.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar recuperar el usuario de la base de datos", e);
            }
            finally
            {
                this.CloseConnection();
            }

            return esp;
        }

        /// <summary>
        /// Elimina la especialidad que tenga la id indicada
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();

                SqlCommand deleteCom = new SqlCommand("delete especialidades where id_especialidad = @id", SqlCon);

                deleteCom.Parameters.AddWithValue("@id", id);

                deleteCom.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar eliminar especialidad", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Inserta una nueva especialidad en la base de datos
        /// </summary>
        /// <param name="especialidad"></param>
        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand insertCom =
                    new SqlCommand("insert into especialidades (desc_especialidad) values (@descripcion) " +
                                   "select @@identity", SqlCon);

                insertCom.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);
                especialidad.ID = decimal.ToInt32((decimal) insertCom.ExecuteScalar());

            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar agregar usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Actualiza la especialidad dada en la base de datos
        /// </summary>
        /// <param name="especialidad"></param>
        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand updateCom = new SqlCommand("update especialidades set desc_especialidad = @descripcion " +
                                                      "id_especialidad = @id", SqlCon);

                updateCom.Parameters.AddWithValue("@id", especialidad.ID);
                updateCom.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);

                updateCom.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar modificar los datos de la especialidad", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Guarda los cambios realizados a la especialidad
        /// </summary>
        /// <param name="especialidad"></param>
        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }

            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
