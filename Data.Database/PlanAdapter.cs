using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        protected SqlDataAdapter _daPlanes;

        /// <summary>
        /// Devuelve una lista con todos los planes
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                OpenConnection();

                SqlCommand comPlanes = new SqlCommand("select * from planes where baja_logica = 0", SqlCon);

                SqlDataReader drPlanes = comPlanes.ExecuteReader();

                while(drPlanes.Read())
                {
                    Plan pl = new Plan();

                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IdEspecialidad = (int)drPlanes["id_especialidad"];
                    pl.Baja = (bool)drPlanes["baja_logica"];
                    planes.Add(pl);
                }

                drPlanes.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar los planes de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return planes;
        }

        /// <summary>
        /// Devuelve el plan que tenga la id indicada
        /// </summary>
        /// <param name="id">identificador del plan</param>
        /// <returns></returns>
        public Plan GetOne(int id)
        {
            Plan pl = new Plan();

            try
            {
                OpenConnection();

                SqlCommand comPlan = new SqlCommand("select * from planes where id_plan = @id and baja_logica = 0", SqlCon);

                comPlan.Parameters.AddWithValue("@id", id);

                SqlDataReader drPlan = comPlan.ExecuteReader();

                if (drPlan.Read())
                {
                    pl.ID = (int) drPlan["id_plan"];
                    pl.Descripcion = (string)drPlan["desc_plan"];
                    pl.IdEspecialidad = (int)drPlan["id_especialidad"];
                    pl.Baja = (bool)drPlan["baja_logica"];
                }

                drPlan.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar recuperar el plan de la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }

            return pl;
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                SqlCommand comDelete = new SqlCommand("delete planes where id_plan = @id", SqlCon);

                
                comDelete.Parameters.AddWithValue("@id", id);

                comDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar el plan", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Inserta un nuevo plan en la base de datos
        /// </summary>
        /// <param name="plan"></param>
        protected void Insert(Plan plan)
        {
            try
            {
                OpenConnection();

                SqlCommand comInsert = new SqlCommand("insert into planes (desc_plan, id_especialidad, baja_logica) values (@descripcion, @especialidad,@baja_logica) " +
                    "select @@identity", SqlCon);

                comInsert.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                comInsert.Parameters.AddWithValue("@especialidad", plan.IdEspecialidad);
                comInsert.Parameters.AddWithValue("@baja_logica", plan.Baja);
                plan.ID = decimal.ToInt32((decimal) comInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar agregar el plan", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                OpenConnection();

                SqlCommand comUpdate = new SqlCommand("update planes set desc_plan = @descripcion, id_especialidad = @especialidad, baja_logica = @baja_logica "
                    + "where id_plan = @id and baja_logica = 0", SqlCon);

                comUpdate.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                comUpdate.Parameters.AddWithValue("@especialidad", plan.IdEspecialidad);
                comUpdate.Parameters.AddWithValue("@baja_logica", plan.Baja);
                comUpdate.Parameters.AddWithValue("@id", plan.ID);

                comUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar los datos del plan", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                Insert(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                Update(plan);
            }

            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}
