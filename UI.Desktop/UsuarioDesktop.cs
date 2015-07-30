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
            PersonaLogic per = new PersonaLogic();

            try
            {
                PersonaActual = per.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception e)
            {
                Notificar("Error inesperado", e.Message + "\nIntente realizar la operacion nuevamente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Persona PersonaActual { get; set; }

        protected override void MapearDeDatos() 
        {
            // Se copian los datos del usuario actual en los textboxes
            this.chkHabilitado.Checked = this.PersonaActual.UsuarioPersona.Habilitado;
            this.txtUsuario.Text = this.PersonaActual.UsuarioPersona.NombreUsuario;
            txtApellido.Text = PersonaActual.Apellido;
            txtNombre.Text = PersonaActual.Nombre;
            txtID.Text = PersonaActual.ID.ToString();
            txtEmail.Text = PersonaActual.Email;
            

            // Cambiamos el texto del boton aceptar segun corresponda
            // Si el formulario es para eliminar el usuario desactiva los textboxes
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
                this.txtClave.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
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
                Persona per = new Persona();
                PersonaActual = per;
                PersonaActual.State = BusinessEntity.States.New;
                
            }
            if (this.Modo == ModoForm.Modificacion)
            {
                PersonaActual.ID = int.Parse(this.txtID.Text);
                PersonaActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                PersonaActual.ID = int.Parse(txtID.Text);
                PersonaActual.State = BusinessEntity.States.Deleted;
            }

            PersonaActual.Nombre = this.txtNombre.Text;
            PersonaActual.Apellido = this.txtApellido.Text;
            PersonaActual.UsuarioPersona.NombreUsuario = this.txtUsuario.Text;
            PersonaActual.Email = this.txtEmail.Text;
            PersonaActual.UsuarioPersona.Clave = Util.Hash.SHA256ConSal(this.txtClave.Text, null);

            PersonaActual.UsuarioPersona.Habilitado = this.chkHabilitado.Checked;
        }

        protected override void GuardarCambios()
        {
            MapearADatos();

            PersonaLogic usr = new PersonaLogic();

            try
            {
                usr.Save(PersonaActual);
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
            // las contraseñas se validan solo si estamos en modo Alta, ya que no se pueden modificar en modo Modificacion
            // ni en modo Baja
            if (Modo == ModoForm.Alta)
            {
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
