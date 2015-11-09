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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private List<Especialidad> _especialidades;
        private Dictionary<int, string> _meses;
        private Dictionary<int, string> _tipoPersona;
        private List<Plan> _planes;

        public UsuarioDesktop()
        {
            InitializeComponent();
            CargarFechas();

            PlanLogic planLogic = new PlanLogic();
            _planes = planLogic.GetAll();

            CargarEspecialidades();
            CargarPlanes();
            CargarTiposPersonas();
        }

        private void CargarEspecialidades()
        {
            EspecialidadLogic especialidadLogic = new EspecialidadLogic();
            _especialidades = especialidadLogic.GetAll();

            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.DisplayMember = "Descripcion";
            cbEspecialidad.DataSource = _especialidades;
            
        }

        private void CargarTiposPersonas()
        {
            _tipoPersona = new Dictionary<int, string>();
            _tipoPersona.Add(0, "Administrativo");
            _tipoPersona.Add(1, "Docente");
            _tipoPersona.Add(2, "Alumno");
            cbTipoPersona.DataSource = new BindingSource(_tipoPersona, null);
            cbTipoPersona.DisplayMember = "Value";
            cbTipoPersona.ValueMember = "Key";
        }

        private void CargarPlanes()
        {
            List<Plan> planesCombo = _planes.FindAll(x => x.IdEspecialidad == (int)cbEspecialidad.SelectedValue);

            cbIdPlan.DataSource = planesCombo;
            cbIdPlan.ValueMember = "ID";
            cbIdPlan.DisplayMember = "Descripcion";
        }

        public UsuarioDesktop(ModoForm modo):this ()
        {
            Modo = modo;  
        }



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

            cbAnio.DataSource = anios;
            cbMes.DataSource = new BindingSource(_meses, null);
            cbMes.DisplayMember = "Value";
            cbMes.ValueMember = "Key";
            cbDia.DataSource = dias;
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
                Notificar(e);
            }
        }

        private Persona PersonaActual { get; set; }

        protected override void MapearDeDatos() 
        {
            // Se copian los datos del usuario actual en los textboxes
            chkHabilitado.Checked = PersonaActual.Habilitado;
            txtUsuario.Text = PersonaActual.NombreUsuario;
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
            cbAnio.SelectedIndex = cbAnio.FindStringExact(PersonaActual.FechaNacimiento.Year.ToString());
            cbMes.SelectedIndex = cbMes.FindStringExact(_meses[PersonaActual.FechaNacimiento.Month]);
            cbDia.SelectedIndex = cbDia.FindStringExact(PersonaActual.FechaNacimiento.Day.ToString());
            // buscamos el plan al que pertenece la persona y luego la especialidad que tiene ese plan
            Plan p = _planes.Find(x => x.ID == PersonaActual.IdPlan);
            cbEspecialidad.SelectedValue = _especialidades.Find(y => y.ID == p.IdEspecialidad).ID;
            cbIdPlan.SelectedValue = PersonaActual.IdPlan;
            cbTipoPersona.SelectedIndex = cbTipoPersona.FindStringExact(_tipoPersona[(int) PersonaActual.TipoPersona]);
            // Cambiamos el texto del boton aceptar segun corresponda
            // Si el formulario es para eliminar el usuario desactiva los textboxes
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
                txtClave.Enabled = false;
                txtConfirmarClave.Enabled = false;
            }
            else if (Modo == ModoForm.Baja)
            {
                txtID.Enabled = false;
                chkHabilitado.Enabled = false;
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
                txtUsuario.Enabled = false;
                txtEmail.Enabled = false;
                txtClave.Enabled = false;
                txtConfirmarClave.Enabled = false;
                txtDireccion.Enabled = false;
                txtLegajo.Enabled = false;
                txtTelefono.Enabled = false;
                cbAnio.Enabled = false;
                cbMes.Enabled = false;
                cbDia.Enabled = false;
                cbEspecialidad.Enabled = false;
                cbIdPlan.Enabled = false;
                cbTipoPersona.Enabled = false;
                btnAceptar.Text = "Eliminar";
            }
         
        }

        protected override void MapearADatos()
        {
            // Si el modo del form es Alta, creamos un nuevo usuario con estado New
            // Si es una modificacion usamos el usuarioactual y cambiamos su estado a modified
            if (Modo == ModoForm.Alta)
            {
                Persona per = new Persona();
                PersonaActual = per;
                PersonaActual.State = BusinessEntity.States.New;
                PersonaActual.Clave = Util.Hash.SHA256ConSal(txtClave.Text, null);
            }
            if (Modo == ModoForm.Modificacion)
            {
                PersonaActual.ID = int.Parse(txtID.Text);
                PersonaActual.State = BusinessEntity.States.Modified;
            }
            if (Modo == ModoForm.Baja)
            {
                PersonaActual.ID = int.Parse(txtID.Text);
                PersonaActual.Baja = true;
                PersonaActual.State = BusinessEntity.States.Modified;
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
            DateTime fechaNac = new DateTime((int)cbAnio.SelectedItem, cbMes.SelectedIndex + 1, (int)cbDia.SelectedItem);
            PersonaActual.FechaNacimiento = fechaNac;
            PersonaActual.Direccion = txtDireccion.Text;
            PersonaActual.Telefono = txtTelefono.Text;
            PersonaActual.IdPlan = (int)cbIdPlan.SelectedValue;
            PersonaActual.TipoPersona = (Persona.TipoPersonas)cbTipoPersona.SelectedValue;
            PersonaActual.Habilitado = chkHabilitado.Checked;
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
                Notificar(e);
            }
        }

        protected override bool Validar() 
        { 
            string msgError = "";
            bool retorno = true;
            int temp;
            
            if (!Regex.IsMatch(this.txtEmail.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
            {
                msgError += "Debe ingresar un email valido\n";
                retorno = false;
            }
            if (txtNombre.TextLength == 0)
            {
                msgError += "El campo \"Nombre\" no puede estar vacio\n";
                retorno = false;
            }
            
            if (txtApellido.TextLength == 0)
            {
                msgError += "El campo \"Apellido\" no puede estar vacio\n";
                retorno = false;
            }
            if (txtUsuario.TextLength == 0)
            {
                msgError += "El campo \"Usuario\" no puede estar vacio\n";
                retorno = false;
            }
            else
            {
                if (Modo == ModoForm.Alta && !PersonaLogic.ValidaUsuario(txtUsuario.Text))
                {
                    msgError += "El nombre de usuario ya existe\n";
                    retorno = false;
                }
                if (Modo == ModoForm.Modificacion && txtUsuario.Text != PersonaActual.NombreUsuario && !PersonaLogic.ValidaUsuario(txtUsuario.Text))
                {
                    msgError += "El nombre de usuario ya existe\n";
                    retorno = false;
                }
            }
            if (txtLegajo.TextLength == 0)
            {
                msgError += "El campo \"Legajo\" no puede estar vacio\n";
                retorno = false;
            }
            else
            {
                if (Modo == ModoForm.Alta && !PersonaLogic.ValidaLegajo(int.Parse(txtLegajo.Text)))
                {
                    msgError += "El legajo ingresado ya posee usuario\n";
                    retorno = false;
                }
                if (Modo == ModoForm.Modificacion && txtLegajo.Text != PersonaActual.Legajo.ToString() && !PersonaLogic.ValidaLegajo(int.Parse(txtLegajo.Text)))
                {
                    msgError += "El legajo ingresado ya posee usuario\n";
                    retorno = false;
                }
            }
            if (txtLegajo.TextLength > 0 && int.TryParse(txtLegajo.Text, out temp) == false)
            {
                msgError += "El campo \"Legajo\" debe ser un entero\n";
                retorno = false;
            }
            if (cbEspecialidad.SelectedValue == null)
            {
                msgError += "Debe seleccionar una especialidad para la persona\n";
                retorno = false;
            }
            if (cbIdPlan.SelectedValue == null)
            {
                msgError += "Debe seleccionar un plan para la persona\n";
                retorno = false;
            }
            if (cbTipoPersona.SelectedValue == null)
            {
                msgError += "Debe seleccionar un tipo de persona\n";
                retorno = false;
            }
            // las contraseñas se validan solo si estamos en modo Alta, ya que no se pueden modificar en modo Modificacion
            // ni en modo Baja
            if (Modo == ModoForm.Alta)
            {
                if (txtClave.Text != txtConfirmarClave.Text)
                {
                    msgError += "Las claves no coinciden\n";
                    retorno = false;
                }
                if (txtClave.TextLength < 8)
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
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Validar() == true)
                {
                    GuardarCambios();
                    Close();
                }
            }
            else if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (cbMes.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth((int)cbAnio.SelectedItem, cbMes.SelectedIndex + 1);


                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                cbDia.DataSource = dias;
            }
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (cbAnio.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth((int)cbAnio.SelectedItem, cbMes.SelectedIndex + 1);

                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                cbDia.DataSource = dias;
            }
        }

        private void cbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPlanes();
        }
    }
}
