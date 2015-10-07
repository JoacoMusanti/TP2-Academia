using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {
        protected SqlDataAdapter _daPersonas;

        /// <summary>
        /// Devuelve una lista con todas las personas en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();


            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("select * from dbo.personas where baja_logica = 0", SqlCon);

                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                while (drPersona.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IdPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    per.Clave = (byte[])drPersona["clave"];
                    per.Habilitado = (bool)drPersona["habilitado"];
                    per.NombreUsuario = (string)drPersona["nombre_usuario"];
                    per.CambiaClave = (int)drPersona["cambia_clave"];
                    per.Baja = (bool)drPersona["baja_logica"];
                    

                    personas.Add(per);
                }

                drPersona.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                personas = null;
                Exception manejada = new Exception("Error al intentar recuperar las personas de la base de datos", e);
                throw manejada;
            }
            finally
            {
                CloseConnection();
                
            }
            

            return personas;
        }

        /// <summary>
        /// Devuelve la persona que tenga la id indicada
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("select * from dbo.personas where id_persona = @id and baja_logica = 0", SqlCon);
                cmdPersona.Parameters.AddWithValue("@id", ID);

                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IdPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    per.Clave = (byte[])drPersona["clave"];
                    per.Habilitado = (bool)drPersona["habilitado"];
                    per.NombreUsuario = (string)drPersona["nombre_usuario"];
                    per.CambiaClave = (int)drPersona["cambia_clave"];
                    per.Baja = (bool)drPersona["baja_logica"];
                }

                drPersona.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                per = null;
                Exception manejada = new Exception("Error al intentar recuperar la persona de la base de datos", e);
                throw manejada;
            }
            finally
            {
                CloseConnection();
                
            }

            return per;
        }

        /// <summary>
        /// Elimina la persona que tenga la id indicada
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete dbo.personas where id_persona=@id", SqlCon);

                cmdDelete.Parameters.AddWithValue("@id", ID);

                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar la persona", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Inserta una nueva persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        protected void Insert(Persona persona)
        {
            try
            {
                OpenConnection();

                SqlCommand com = new SqlCommand("insert into dbo.personas (nombre, apellido,email,direccion,fecha_nac,id_plan,legajo,telefono,tipo_persona, nombre_usuario, "
                    + "clave, habilitado, cambia_clave, baja_logica) values (@nombre, @apellido,@email,@direccion,@fecha_nac,@id_plan,@legajo,@telefono,@tipo_persona, @nombre_usuario, "
                    + "@clave, @habilitado,@cambia_clave,@baja_logica) select @@identity", SqlCon);

                com.Parameters.AddWithValue("@nombre", persona.Nombre);
                com.Parameters.AddWithValue("@apellido", persona.Apellido);
                com.Parameters.AddWithValue("@email", persona.Email);
                com.Parameters.AddWithValue("@direccion", persona.Direccion);
                com.Parameters.AddWithValue("@fecha_nac", persona.FechaNacimiento);
                com.Parameters.AddWithValue("@id_plan", persona.IdPlan);
                com.Parameters.AddWithValue("@legajo", persona.Legajo);
                com.Parameters.AddWithValue("@telefono", persona.Telefono);
                com.Parameters.AddWithValue("@tipo_persona", persona.TipoPersona);
                com.Parameters.AddWithValue("@nombre_usuario", persona.NombreUsuario);
                com.Parameters.AddWithValue("@clave", persona.Clave);
                com.Parameters.AddWithValue("@habilitado", persona.Habilitado);
                com.Parameters.AddWithValue("@cambia_clave", persona.CambiaClave);
                com.Parameters.AddWithValue("@baja_logica", persona.Baja);
                persona.ID = decimal.ToInt32((decimal) com.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar la persona", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Actualiza la persona dada con los nuevos datos en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        protected void Update(Persona persona)
        {
            try
            {
                OpenConnection();
                
                SqlCommand updateCom = new SqlCommand("update dbo.personas set "
                    + "nombre = @nombre, apellido = @apellido, email = @email, direccion = @direccion,fecha_nac=@fecha_nac,id_plan=@id_plan,legajo=@legajo, telefono=@telefono,tipo_persona=@tipo_persona,"
                    + "nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado, cambia_clave=@cambia_clave, baja_logica=@baja_logica where "
                    + "id_persona = @id and baja_logica = 0", SqlCon);
                updateCom.Parameters.AddWithValue("@nombre", persona.Nombre);
                updateCom.Parameters.AddWithValue("@apellido", persona.Apellido);
                updateCom.Parameters.AddWithValue("@email", persona.Email);
                updateCom.Parameters.AddWithValue("@direccion", persona.Direccion);
                updateCom.Parameters.AddWithValue("@fecha_nac", persona.FechaNacimiento);
                updateCom.Parameters.AddWithValue("@id_plan", persona.IdPlan);
                updateCom.Parameters.AddWithValue("@legajo", persona.Legajo);
                updateCom.Parameters.AddWithValue("@telefono", persona.Telefono);
                updateCom.Parameters.AddWithValue("@tipo_persona", persona.TipoPersona);
                updateCom.Parameters.AddWithValue("@nombre_usuario", persona.NombreUsuario);
                updateCom.Parameters.AddWithValue("@clave", persona.Clave);
                updateCom.Parameters.AddWithValue("@habilitado", persona.Habilitado);
                updateCom.Parameters.AddWithValue("@cambia_clave", persona.CambiaClave);
                updateCom.Parameters.AddWithValue("@baja_logica", persona.Baja);
                updateCom.Parameters.AddWithValue("@id", persona.ID);

                    
                    updateCom.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar datos de la persona", e);
            }
            finally
            {
                CloseConnection();
            }
        }
        
        /// <summary>
        /// Guarda los cambios realizados de la persona
        /// </summary>
        /// <param name="persona"></param>
        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;            
        }

        /// <summary>
        /// Devuelve el usuario que tenga el nombre de la persona indicada
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Persona GetOne(string nameuser)
        {
            Persona per = new Persona();

            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("select * from dbo.personas where nombre_usuario = @nombreusuario", SqlCon);
                cmdPersona.Parameters.AddWithValue("@nombreusuario", nameuser);

                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IdPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    per.Clave = (byte[])drPersona["clave"];
                    per.Habilitado = (bool)drPersona["habilitado"];
                    per.NombreUsuario = (string)drPersona["nombre_usuario"];
                    per.CambiaClave = (int)drPersona["cambia_clave"];
                    per.Baja = (bool)drPersona["baja_logica"];
                }

                drPersona.Close();
            }
            catch (Exception e)
            {
                per = null;
                Util.Logger.Log(e);
                Exception manejada = new Exception("Error al intentar recuperar la persona de la base de datos", e);
                throw manejada;
            }
            finally
            {
                CloseConnection();

            }

            return per;
        }

        public Persona GetOneLeg(int legajo)
        {
            Persona per = new Persona();

            try
            {
                OpenConnection();

                SqlCommand cmdPersona = new SqlCommand("select * from dbo.personas where legajo = @legajo", SqlCon);
                cmdPersona.Parameters.AddWithValue("@legajo", legajo);

                SqlDataReader drPersona = cmdPersona.ExecuteReader();

                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.IdPlan = (int)drPersona["id_plan"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.Telefono = (string)drPersona["telefono"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersona["tipo_persona"];
                    per.Clave = (byte[])drPersona["clave"];
                    per.Habilitado = (bool)drPersona["habilitado"];
                    per.NombreUsuario = (string)drPersona["nombre_usuario"];
                    per.CambiaClave = (int)drPersona["cambia_clave"];
                    per.Baja = (bool)drPersona["baja_logica"];
                }

                drPersona.Close();
            }
            catch (Exception e)
            {
                per = null;
                Util.Logger.Log(e);
                Exception manejada = new Exception("Error al intentar recuperar la persona de la base de datos", e);
                throw manejada;
            }
            finally
            {
                CloseConnection();

            }

            return per;
        }
    }
}
