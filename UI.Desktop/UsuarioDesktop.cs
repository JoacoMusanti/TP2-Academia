using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo):this ()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo): this()
        {
            Modo = modo;
            UsuarioLogic usr = new UsuarioLogic();

            try
            {
                UsuarioActual = usr.GetOne(ID);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MapearDeDatos();
        }

        private Usuario UsuarioActual { get; set; }

        protected override void MapearDeDatos() 
        {
            // Se copian los datos del usuario actual en los textboxes
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtEmail.Text = this.UsuarioActual.EMail;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            // Cambiamos el texto del boton aceptar segun corresponda
            // Si el formulario es para eliminar el usuario desactiva los textboxes
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.txtID.Enabled = false;
                this.chkHabilitado.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtUsuario.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
                this.btnAceptar.Text = "Eliminar";
            }
         
        }

        protected override void MapearADatos()
        {
            // Si el modo del form es Alta, creamos un nuevo usuario con estado New
            // Si es una modificacion usamos el usuarioactual y cambiamos su estado a modified
            if (this.Modo == ModoForm.Alta)
            {
                Usuario usr = new Usuario();
                UsuarioActual = usr;
                UsuarioActual.State = BusinessEntity.States.New;
                
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                UsuarioActual.ID = int.Parse(this.txtID.Text);
                UsuarioActual.State = BusinessEntity.States.Modified;
            }

            UsuarioActual.Nombre = this.txtNombre.Text;
            UsuarioActual.Apellido = this.txtApellido.Text;
            UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            UsuarioActual.EMail = this.txtEmail.Text;
            UsuarioActual.Clave = this.txtClave.Text;

            UsuarioActual.Habilitado = this.chkHabilitado.Checked;
        }

        protected override void GuardarCambios()
        {
            MapearADatos();

            UsuarioLogic usr = new UsuarioLogic();

            try
            {
                usr.Save(UsuarioActual);
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override bool Validar() 
        { 
            string msgError = "";
            bool retorno = true;
            //if (Regex.Match(this.txtEmail.Text, "[A-Za-z0-9]@[A-Za-z0-9].[A-Za-z]")  )
            if (this.txtNombre.TextLength == 0)
            {
                msgError += "El campo \"Nombre\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtApellido.TextLength == 0)
            {
                msgError += "El campo \"Apellido\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtClave.TextLength == 0)
            {
                msgError += "El campo \"Clave\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtConfirmarClave.TextLength == 0)
            {
                msgError += "El campo \"Confirmar Clave\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtEmail.TextLength == 0)
            {
                msgError += "El campo \"Email\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtUsuario.TextLength == 0)
            {
                msgError += "El campo \"Usuario\" no puede estar vacio\n";
                retorno = false;
            }
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                msgError += "Las claves no coinciden\n";
                retorno = false;
            }
            if (this.txtClave.TextLength < 8)
            {
                msgError += "La clave no puede tener menos de 8 caracteres\n";
                retorno = false;
            }

            if (retorno == false)
            {
                Notificar(msgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (Validar() == true)
                {
                    GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                GuardarCambios();
                this.Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

    }
}
