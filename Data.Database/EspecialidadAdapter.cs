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
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar recuperar las especialidades", e);
            }
            finally
            {
                this.CloseConnection();
            }

            return especialidades;
        }
    }
}
