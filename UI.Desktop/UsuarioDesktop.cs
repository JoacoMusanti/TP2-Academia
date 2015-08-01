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
            CargarFechas();
            CargarPlanes();
            CargarTiposPersonas();
        }

        private void CargarTiposPersonas()
        {
            _tipoPersona = new Dictionary<int, string>();
            _tipoPersona.Add(0, "Administrativo");
            _tipoPersona.Add(1, "Docente");
            _tipoPersona.Add(2, "Alumno");
            cmbTipoPersona.DataSource = new BindingSource(_tipoPersona, null);
            cmbTipoPersona.DisplayMember = "Value";
            cmbTipoPersona.ValueMember = "Key";
        }

        private void CargarPlanes()
        {
            PlanLogic planLogic = new PlanLogic();
            List<Plan> _planes = planLogic.GetAll();

            cmbIdPlan.DataSource = _planes;
            cmbIdPlan.ValueMember = "ID";
            cmbIdPlan.DisplayMember = "Descripcion";
        }

        public UsuarioDesktop(ModoForm modo):this ()
        {
            Modo = modo;  
        }

        private Dictionary<int, string> _meses;
        private Dictionary<int, string> _tipoPersona;

        private void CargarFechas()
        {
            _meses = new Dictionary<int, string>();
            List<int> anios = new List<int>(100);
            List<int> dias = new List<int>(31);

            for (int i = 0; i < 100; i++)
            {
                anios.Add(DateTime.Now.Year - i);
                if (i < 31)
                {
                    dias.Add(i + 1);
                }
            }

            _meses.Add(1, "Enero");
            _meses.Add(2, "Febrero");
            _meses.Add(3, "Marzo");
            _meses.Add(4, "Abril");
            _meses.Add(5, "Mayo");
            _meses.Add(6, "Junio");
            _meses.Add(7, "Julio");
            _meses.Add(8, "Agosto");
            _meses.Add(9, "Septiembre");
            _meses.Add(10, "Octubre");
            _meses.Add(11, "Noviembre");
            _meses.Add(12, "Diciembre");

            cmbAnio.DataSource = anios;
            cmbMes.DataSource = new BindingSource(_meses, null);
            cmbMes.DisplayMember = "Value";
            cmbMes.ValueMember = "Key";
            cmbDia.DataSource = dias;
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
            this.chkHabilitado.Checked = this.PersonaActual.Habilitado;
            this.txtUsuario.Text = this.PersonaActual.NombreUsuario;
            txtApellido.Text = PersonaActual.Apellido;
            txtNombre.Text = PersonaActual.Nombre;
            txtID.Text = PersonaActual.ID.ToString();
            txtEmail.Text = PersonaActual.Email;
            txtTelefono.Text = PersonaActual.Telefono;
            txtDireccion.Text = PersonaActual.Direccion;
            txtLegajo.Text = PersonaActual.Legajo.ToString();

            // NO CAMBIAR EL ORDEN DE EL SETEO DE LA FECHA
            // LOS DIAS SE ACTUALIZAN SEGUN EL MES Y AÑO ELEGIDOS POR LO CUAL SE DEBE
            // SETEAR ULTIMO
            cmbAnio.SelectedIndex = cmbAnio.FindStringExact(PersonaActual.FechaNacimiento.Year.ToString());
            cmbMes.SelectedIndex = cmbMes.FindStringExact(_meses[PersonaActual.FechaNacimiento.Month]);
            cmbDia.SelectedIndex = cmbDia.FindStringExact(PersonaActual.FechaNacimiento.Day.ToString());
            cmbIdPlan.SelectedValue = PersonaActual.IdPlan;
            cmbTipoPersona.SelectedIndex = cmbTipoPersona.FindStringExact(_tipoPersona[(int) PersonaActual.TipoPersona]);
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
                txtDireccion.Enabled = false;
                txtLegajo.Enabled = false;
                txtTelefono.Enabled = false;
                cmbAnio.Enabled = false;
                cmbMes.Enabled = false;
                cmbDia.Enabled = false;
                cmbIdPlan.Enabled = false;
                cmbTipoPersona.Enabled = false;
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

            // no hace falta validar la fecha y el legajo aca ya que la validacion se realiza
            // en el metodo validar
            if (txtLegajo.TextLength > 0)
            {
                PersonaActual.Legajo = int.Parse(txtLegajo.Text);
            }

            PersonaActual.Nombre = txtNombre.Text;
            PersonaActual.Apellido = txtApellido.Text;
            PersonaActual.NombreUsuario = txtUsuario.Text;
            PersonaActual.Email = txtEmail.Text;
            DateTime fechaNac = new DateTime((int)cmbAnio.SelectedItem, cmbMes.SelectedIndex + 1, (int)cmbDia.SelectedItem);
            PersonaActual.FechaNacimiento = fechaNac;
            PersonaActual.Direccion = txtDireccion.Text;
            PersonaActual.Telefono = txtTelefono.Text;
            PersonaActual.Clave = Util.Hash.SHA256ConSal(this.txtClave.Text, null);
            PersonaActual.IdPlan = (int)cmbIdPlan.SelectedValue;
            PersonaActual.TipoPersona = (Persona.TipoPersonas)cmbTipoPersona.SelectedValue;
            PersonaActual.Habilitado = this.chkHabilitado.Checked;
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
            int temp;
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
            if (this.txtUsuario.TextLength == 0)
            {
                msgError += "El campo \"Usuario\" no puede estar vacio\n";
                retorno = false;
            }
            if (txtLegajo.TextLength > 0 && int.TryParse(txtLegajo.Text, out temp) == false)
            {
                msgError += "El campo \"Legajo\" debe ser un entero\n";
                retorno = false;
            }
            if (cmbIdPlan.SelectedValue == null)
            {
                msgError += "Debe seleccionar un plan para la persona\n";
                retorno = false;
            }
            if (cmbTipoPersona.SelectedValue == null)
            {
                msgError += "Debe seleccionar un tipo de persona\n";
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

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (cmbMes.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth((int)cmbAnio.SelectedItem, cmbMes.SelectedIndex + 1);


                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                cmbDia.DataSource = dias;
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (cmbAnio.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth((int)cmbAnio.SelectedItem, cmbMes.SelectedIndex + 1);

                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                cmbDia.DataSource = dias;
            }
        }
    }
}
