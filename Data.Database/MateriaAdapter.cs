using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class MateriaAdapter:Adapter
    {
        protected SqlDataAdapter _daMaterias;

        
        public Materia GetOne(int id)
        {
            Materia mat = new Materia();

            try
            {
                OpenConnection();

                SqlCommand comMateria = new SqlCommand("select * from materias where @id=id_materia",SqlCon);

                comMateria.Parameters.Add("@id", id);

                SqlDataReader drMaterias = comMateria.ExecuteReader();

                if(drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HorasSemanales = (int)drMaterias["hs_semanales"];
                    mat.HorasTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];
                }

                drMaterias.Close();
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

             return mat;
        }

        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                OpenConnection();

                SqlCommand comMaterias = new SqlCommand ("select * from materias",SqlCon);

                SqlDataReader drMaterias = comMaterias.ExecuteReader();

                while(drMaterias.Read())
                {
                    Materia mat = new Materia();
                   
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HorasSemanales = (int)drMaterias["hs_semanales"];
                    mat.HorasTotales = (int)drMaterias["hs_totales"];
                    mat.IdPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);
                }

                drMaterias.Close();
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

            return materias;  
        }

        public void Save(Materia materia)
        {
           if(materia.State == BusinessEntity.States.New)
           {
               Insert(materia);
           }

           if(materia.State == BusinessEntity.States.Modified)
           {
               Update(materia);
           }

           if(materia.State == BusinessEntity.States.Deleted)
           {
               Delete(materia.ID);
           }

            materia.State = BusinessEntity.States.Unmodified;
        }

        public void Insert(Materia mat)
        {
            try
            {
                OpenConnection();

                SqlCommand comInsert = new SqlCommand("Insert into materias (desc_materia,hs_semanales,hs_totales,id_plan) values (@desc_materia,@hs_semanales,@hs_totales,@idPlan) select @@identity",SqlCon);

                comInsert.Parameters.Add("@desc_materia",mat.Descripcion);
                comInsert.Parameters.Add("@hs_semanales",mat.HorasSemanales);
                comInsert.Parameters.Add("@hs_totales",mat.HorasTotales);
                comInsert.Parameters.Add("@id_plan",mat.IdPlan);

                mat.ID = decimal.ToInt32((decimal)comInsert.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar la materia en la base de datos", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Update(Materia mat)
        {
            try
            {
                OpenConnection();

                SqlCommand comUpdate = new SqlCommand("update materias set desc_materia = @desc_materia,hs_semanales=@hs_semanales,hs_totales=@hs_totales,id_plan = @id_plan where id_materia=@id_materia",SqlCon);

                comUpdate.Parameters.Add("@desc_materia",mat.Descripcion);
                comUpdate.Parameters.Add("@hs_semanales",mat.HorasSemanales);
                comUpdate.Parameters.Add("@hs_totales",mat.HorasTotales);
                comUpdate.Parameters.Add("@id_plan",mat.IdPlan);
                comUpdate.Parameters.Add("@id_materia",mat.ID);

                comUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar los datos de la materia", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                OpenConnection();

                SqlCommand comDelete = new SqlCommand("delete materias where id_materias = @id_materia",SqlCon);

                comDelete.Parameters.Add("@id_materias",id);

                comDelete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar la materia", e);
            }
            finally
            {
                CloseConnection();
            }
        }

     }
}

