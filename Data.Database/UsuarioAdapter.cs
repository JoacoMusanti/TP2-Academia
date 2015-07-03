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
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.EMail = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.EMail = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.EMail = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        protected SqlDataAdapter _daUsuarios;

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
                    usr.Clave = (string)drUsuarios["clave"];
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

        public Business.Entities.Usuario GetOne(int ID)
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
                    usr.Clave = (string)drUsuario["clave"];
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
                Exception manejada = new Exception("Error al intentar recuperar el usuario de la base de datos", e);
                throw manejada;
            }
            finally
            {
                this.CloseConnection();
                
            }

            return usr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete dbo.usuarios where id_usuario=@id", SqlCon);

                cmdDelete.Parameters.AddWithValue("@id", ID);

                cmdDelete.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("Error al intentar eliminar usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

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
                usuario.ID = (int) com.ExecuteScalar();

                this.CloseConnection();
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar insertar usuario", e);
            }
            finally
            {
                this.CloseConnection();
            }
        }

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
                Usuarios[Usuarios.FindIndex(delegate(Usuario u) { return u.ID == usuario.ID; })]=usuario;
            }
            usuario.State = BusinessEntity.States.Unmodified;            
        }
    }
}
