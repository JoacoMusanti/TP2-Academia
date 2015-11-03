using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Globalization;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private PersonaLogic _logicPersona;
        private PlanLogic _logicPlan;
        private EspecialidadLogic _logicEspecialidad;



        private EspecialidadLogic LogicEspecialidad
        {
            get
            {
                if (_logicEspecialidad == null)
                {
                    _logicEspecialidad = new EspecialidadLogic();
                }

                return _logicEspecialidad;
            }
        }
        private PlanLogic LogicPlan
        {
            get
            {
                if (_logicPlan == null)
                {
                    _logicPlan = new PlanLogic();
                }

                return _logicPlan;
            }
        }
        private PersonaLogic LogicPersona
        {
            get
            {
                if (_logicPersona == null)
                {
                    _logicPersona = new PersonaLogic();
                }

                return _logicPersona;
            }
        }

        private void LoadGrid()
        {
            gridView.DataSource = LogicPersona.GetAll();
            gridView.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TipoPersonas)Session["RolSesion"] == Persona.TipoPersonas.Administrativo)
            {
                LoadGrid();
                if (!IsPostBack)
                {
                    Util.Logger.LogHabilitado = false;
                    CargarFechas();
                    // los dropdown mes y año llaman a la funcion javascript onCambiaFecha()
                    // cuando se dispara el evento onchange (selectedIndexChanged)
                    ddlAnio.Attributes["onchange"] = "onCambiaFecha();";
                    ddlMes.Attributes["onchange"] = "onCambiaFecha();";
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx?mensaje=" + Server.UrlEncode("No tenes permisos para acceder a ese recurso"));
            }

        }

        private Persona PersonaActual { get; set; }
        private Plan PlanUsuario { get; set; }
        private Especialidad EspecialidadUsuario { get; set; }


        private int? SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int?)ViewState["SelectedID"];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID.Value != -1);
            }
        }



        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }

        private void CargarFechas()
        {
            CargarAnios();
            CargarMeses();
            CargarDias();
        }

        private void CargarDias()
        {
            List<int> dias = new List<int>();

            for (int i = 1; i < 32; i++)
            {
                dias.Add(i);
            }

            ddlDia.DataSource = dias;
            ddlDia.DataBind();
        }

        private void CargarMeses()
        {
            Dictionary<int, string> meses = new Dictionary<int, string>();

            for (int i = 1; i < 13; i++)
            {
                meses.Add(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i));
            }

            ddlMes.DataSource = meses;
            ddlMes.DataValueField = "Key";
            ddlMes.DataTextField = "Value";
            ddlMes.DataBind();
        }

        private void CargarAnios()
        {
            List<int> anios = new List<int>(100);

            for (int i = 0; i < 100; i++)
            {
                anios.Add(DateTime.Now.Year - i);
            }

            ddlAnio.DataSource = anios;
            ddlAnio.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int?)gridView.SelectedValue;
            
            formPanel.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;
        }

        private void CargarTiposPersonas()
        {
            Dictionary<int, string> tipoPersona = new Dictionary<int, string>();
            tipoPersona.Add(0, "Administrativo");
            tipoPersona.Add(1, "Docente");
            tipoPersona.Add(2, "Alumno");
            ddlTipoPersona.DataSource = tipoPersona;
            ddlTipoPersona.DataTextField = "Value";
            ddlTipoPersona.DataValueField = "Key";
            ddlTipoPersona.DataBind();
        }

        private void LimpiarForm()
        {
            txtClave.Enabled = true;
            txtRepetirClave.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            chkHabilitado.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtDireccion.Enabled = true;
            txtLegajo.Enabled = true;
            txtTelefono.Enabled = true;

            ddlAnio.Enabled = true;
            ddlMes.Enabled = true;
            ddlDia.Enabled = true;
            ddlEspecialidad.Enabled = true;
            ddlIdPlan.Enabled = true;
            ddlTipoPersona.Enabled = true;
        }

        private void LoadForm(int id)
        {
            CargarTiposPersonas();
            CargarPlanes();
            CargarEspecialidades();

            if (FormMode == FormModes.Baja)
            {
                txtClave.Enabled = false;
                txtRepetirClave.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                chkHabilitado.Enabled = false;
                txtNombreUsuario.Enabled = false;
                txtDireccion.Enabled = false;
                txtLegajo.Enabled = false;
                txtTelefono.Enabled = false;

                ddlAnio.Enabled = false;
                ddlMes.Enabled = false;
                ddlDia.Enabled = false;
                ddlEspecialidad.Enabled = false;
                ddlIdPlan.Enabled = false;
                ddlTipoPersona.Enabled = false;
            }
            else
            {
                txtClave.Enabled = false;
                txtRepetirClave.Enabled = false;
                txtNombre.Enabled = true;
                txtApellido.Enabled = true;
                txtEmail.Enabled = true;
                chkHabilitado.Enabled = true;
                txtNombreUsuario.Enabled = true;
                txtDireccion.Enabled = true;
                txtLegajo.Enabled = true;
                txtTelefono.Enabled = true;

                ddlAnio.Enabled = true;
                ddlMes.Enabled = true;
                ddlDia.Enabled = true;
                ddlEspecialidad.Enabled = true;
                ddlIdPlan.Enabled = true;
                ddlTipoPersona.Enabled = true;

                cvCoinciden.Enabled = true;
                rfvClave.Enabled = true;
                rfvRepiteClave.Enabled = true;

                LimpiarForm();
            }
            if (FormMode != FormModes.Alta)
            {
                txtClave.Enabled = false;
                txtRepetirClave.Enabled = false;

                cvCoinciden.Enabled = false;
                rfvClave.Enabled = false;
                rfvRepiteClave.Enabled = false;

                PersonaActual = LogicPersona.GetOne(id);
                Session["Persona"] = PersonaActual;
                PlanUsuario = LogicPlan.GetOne(PersonaActual.IdPlan);
                EspecialidadUsuario = LogicEspecialidad.GetOne(PlanUsuario.IdEspecialidad);

                txtNombre.Text = PersonaActual.Nombre;
                txtApellido.Text = PersonaActual.Apellido;
                txtEmail.Text = PersonaActual.Email;
                chkHabilitado.Checked = PersonaActual.Habilitado;
                txtNombreUsuario.Text = PersonaActual.NombreUsuario;
                txtDireccion.Text = PersonaActual.Direccion;
                txtLegajo.Text = PersonaActual.Legajo.ToString();
                txtTelefono.Text = PersonaActual.Telefono;

                ddlAnio.SelectedValue = PersonaActual.FechaNacimiento.Year.ToString();
                ddlMes.SelectedValue = PersonaActual.FechaNacimiento.Month.ToString();
                ddlDia.SelectedValue = PersonaActual.FechaNacimiento.Day.ToString();

                ddlEspecialidad.SelectedValue = PlanUsuario.IdEspecialidad.ToString();
                ddlIdPlan.SelectedValue = PersonaActual.IdPlan.ToString();
                ddlTipoPersona.SelectedIndex = (int)PersonaActual.TipoPersona;
            }
        }

        private void CargarPlanes()
        {
            ddlIdPlan.DataSource = LogicPlan.GetAll();
            ddlIdPlan.DataValueField = "ID";
            ddlIdPlan.DataTextField = "Descripcion";
            ddlIdPlan.DataBind();
        }

        private void CargarEspecialidades()
        {
            ddlEspecialidad.DataSource = LogicEspecialidad.GetAll();
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
        }

        private void LoadEntity()
        {
            if (FormMode == FormModes.Alta)
            {
                PersonaActual = new Persona();
                PersonaActual.ID = SelectedID.Value;
                PersonaActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Modificacion || FormMode == FormModes.Baja)
            {
                PersonaActual = (Persona)Session["Persona"];
                PersonaActual.State = BusinessEntity.States.Modified;
                if (FormMode == FormModes.Baja)
                {
                    PersonaActual.Baja = true;
                }
                else
                {
                    PersonaActual.Baja = false;
                }
            }
            if (FormMode == FormModes.Alta)
            {
                PersonaActual.Clave = Util.Hash.SHA256ConSal(txtClave.Text, null);
            }

            PersonaActual.Nombre = txtNombre.Text;
            PersonaActual.Apellido = txtApellido.Text;
            PersonaActual.Email = txtEmail.Text;
            PersonaActual.NombreUsuario = txtNombreUsuario.Text;
            PersonaActual.Habilitado = chkHabilitado.Checked;

            PersonaActual.Direccion = txtDireccion.Text;
            PersonaActual.FechaNacimiento = new DateTime(int.Parse(ddlAnio.SelectedValue),
                int.Parse(ddlMes.SelectedValue), int.Parse(ddlDia.SelectedValue));
            PersonaActual.IdPlan = int.Parse(ddlIdPlan.SelectedValue);
            PersonaActual.Legajo = int.Parse(txtLegajo.Text);
            PersonaActual.CambiaClave = PersonaActual.CambiaClave;
            PersonaActual.Telefono = txtTelefono.Text;
            PersonaActual.TipoPersona = (Persona.TipoPersonas)ddlTipoPersona.SelectedIndex;
        }

        private void SaveEntity(Persona per)
        {
            LogicPersona.Save(per);
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                formActionsPanel.Visible = true;
                gridActionsPanel.Visible = false;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID.Value);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;

            // Se cargan los datos del form en PersonaActual y luego se persisten en base de datos
            LoadEntity();
            SaveEntity(PersonaActual);
            LoadGrid();
            // LoadGrid no dispara SelectedIndexChanged de la gridview por lo que cambiamos el
            // selected ID manualmente
            gridView.SelectedIndex = -1;
            gridView_SelectedIndexChanged(null, null);
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlIdPlan.DataSource = LogicPlan.GetAll().Where(plan => plan.IdEspecialidad == int.Parse(ddlEspecialidad.SelectedValue));
            ddlIdPlan.DataBind();
        }
        
        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                formActionsPanel.Visible = true;
                gridActionsPanel.Visible = false;

                FormMode = FormModes.Baja;
                LoadForm(SelectedID.Value);
            }
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Alta;

            formPanel.Visible = true;
            formActionsPanel.Visible = true;
            gridActionsPanel.Visible = false;

            LoadForm(SelectedID.Value);
            
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = false;

            gridView.SelectedIndex = -1;
            gridView_SelectedIndexChanged(null, null);
        }

    }
}