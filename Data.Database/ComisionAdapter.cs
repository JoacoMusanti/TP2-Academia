using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        protected SqlDataAdapter _daComisiones;

        /// <summary>
        /// Devuelve una lista con todas las comisiones
        /// </summary>
        /// <returns></returns>
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                OpenConnection();

                SqlCommand comComisiones = new SqlCommand("select * from comisiones", SqlCon);

                SqlDataReader drComisiones = comComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision com = new Comision();

                    com.ID = (int)drComisiones["id_comision"];
                    com.IdPlan = (int)drComisiones["id_plan"];
                    com.Descripcion = (string)drComisiones["desc_comision"];
                    com.AnioEspecialidad = (int)drComisiones["anio_especialidad"];

                    comisiones.Add(com);
                }

                drComisiones.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar las comisiones de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return comisiones;
        }

        /// <summary>
        /// Devuelve la comision que tenga la id indicada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Comision GetOne(int id)
        {
            Comision com = new Comision();

            try
            {
                OpenConnection();

                SqlCommand comComision = new SqlCommand("select * from comisiones where @id = id_comision", SqlCon);

                comComision.Parameters.AddWithValue("@id", id);

                SqlDataReader drComision = comComision.ExecuteReader();

                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    com.IdPlan = (int)drComision["id_plan"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                }

                drComision.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar la comision de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return com;
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                SqlCommand comDelete = new SqlCommand("delete comisiones where id_comision = @id", SqlCon);

                comDelete.Parameters.AddWithValue("@id", id);

                comDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar la comision", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Comision comi)
        {
            try
            {
                OpenConnection();

                SqlCommand comInsert = new SqlCommand("insert into comisiones (desc_comision, anio_especialidad, id_plan) " +
                    " values (@descripcion, @anio, @plan) select @@identity", SqlCon);

                comInsert.Parameters.AddWithValue("@descripcion", comi.Descripcion);
                comInsert.Parameters.AddWithValue("@anio", comi.AnioEspecialidad);
                comInsert.Parameters.AddWithValue("@plan", comi.IdPlan);

                comi.ID = decimal.ToInt32((decimal)comInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar la comision en la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Comision comi)
        {
            try
            {
                OpenConnection();

                SqlCommand comUpdate = new SqlCommand("update comisiones set desc_comision = @desc, anio_especialidad = @anio, " +
                    "id_plan = @plan where id_comision = @id", SqlCon);

                comUpdate.Parameters.AddWithValue("@desc", comi.Descripcion);
                comUpdate.Parameters.AddWithValue("@anio", comi.AnioEspecialidad);
                comUpdate.Parameters.AddWithValue("@plan", comi.IdPlan);
                comUpdate.Parameters.AddWithValue("@id", comi.ID);

                comUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar los datos de la comision", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.New)
            {
                Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                Update(comision);
            }
            else if (comision.State == BusinessEntity.States.Deleted)
            {
                Delete(comision.ID);
            }

            comision.State = BusinessEntity.States.Unmodified;
        }
    }
}
