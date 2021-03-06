using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        protected SqlDataAdapter _daUsuarios;

        /// <summary>
        /// Devuelve una lista con todos los usuarios en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();


            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select * from dbo.usuarios", SqlCon);

                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (byte[])drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.EMail = (string)drUsuarios["email"];

                    usuarios.Add(usr);
                }

                drUsuarios.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                usuarios = null;
                Exception manejada = new Exception("Error al intentar recuperar los usuarios de la base de datos", e);
                throw manejada;
            }
            finally
            {
                this.CloseConnection();
                
            }
            

            return usuarios;
        }

        /// <summary>
        /// Devuelve el usuario que tenga la id indicada
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from dbo.usuarios where id_usuario = @id", SqlCon);
                cmdUsuario.Parameters.AddWithValue("@id", ID);

                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();

                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Clave = (byte[]) drUsuario["clave"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Nombre = (string)drUsuario["nombre"];
                    usr.Apellido = (string)drUsuario["apellido"];
                    usr.EMail = (string)drUsuario["email"];
                }

                drUsuario.Close();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                usr = null;
                Exception manejada = new Exception("Error al intentar recuperar el usuario de la base de datos", e);
                throw manejada;
            }
            finally
            {
                this.CloseConnection();
                
            }

            return usr;
        }

        /// <summary>
        /// Elimina el usuario que tenga la id indicada
        /// </summary>
        /// <param name="ID"></param>
        public void Delete(int ID)
        {
            try
            {
                OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete dbo.usuarios where id_usuario=@id", SqlCon);

                cmdDelete.Parameters.AddWithValue("@id", ID);

                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar eliminar usuario", e);
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand com = new SqlCommand("insert into dbo.usuarios (nombre, apellido, nombre_usuario, "
                    + "clave, habilitado, email, cambia_clave) values (@nombre, @apellido, @nombre_usuario, "
                    + "@clave, @habilitado, @email, @cambia_clave) select @@identity", SqlCon);

                com.Parameters.AddWithValue("@nombre", usuario.Nombre);
                com.Parameters.AddWithValue("@apellido", usuario.Apellido);
                com.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                com.Parameters.AddWithValue("@clave", usuario.Clave);
                com.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                com.Parameters.AddWithValue("@email", usuario.EMail);
                com.Parameters.AddWithValue("@cambia_clave", usuario.CambiaClave);
                usuario.ID = decimal.ToInt32((decimal) com.ExecuteScalar());
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar insertar usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Actualiza el usuario dado con los nuevos datos en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                
                SqlCommand updateCom = new SqlCommand("update dbo.usuarios set "
                    + "nombre_usuario = @nombre_usuario, nombre = @nombre, "
                    + "apellido = @apellido, email = @email, habilitado = @habilitado where "
                    + "id_usuario = @id", SqlCon);
                    
                    updateCom.Parameters.AddWithValue("@id", usuario.ID);
                    updateCom.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                    updateCom.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    updateCom.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    updateCom.Parameters.AddWithValue("@email", usuario.EMail);
                    updateCom.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                    
                    updateCom.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw new Exception("Error al intentar modificar datos del usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        
        /// <summary>
        /// Guarda los cambios realizados al usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }

        /// <summary>
        /// Devuelve el usuario que tenga el nombre de usuario indicado
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Usuario GetOne(string nameuser)
        {
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuario = new SqlCommand("select * from dbo.usuarios where nombre_usuario = @nombreusuario", SqlCon);
                cmdUsuario.Parameters.AddWithValue("@nombreusuario", nameuser);

                SqlDataReader drUsuario = cmdUsuario.ExecuteReader();

                if (drUsuario.Read())
                {
                    usr.ID = (int)drUsuario["id_usuario"];
                    usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    usr.Clave = (byte[])drUsuario["clave"];
                    usr.Habilitado = (bool)drUsuario["habilitado"];
                    usr.Nombre = (string)drUsuario["nombre"];
                    usr.Apellido = (string)drUsuario["apellido"];
                    usr.EMail = (string)drUsuario["email"];
                }

                drUsuario.Close();
            }
            catch (Exception e)
            {
                usr = null;
                Util.Logger.Log(e);
                Exception manejada = new Exception("Error al intentar recuperar el usuario de la base de datos", e);
                throw manejada;
            }
            finally
            {
                this.CloseConnection();

            }

            return usr;
        }
    }
}
