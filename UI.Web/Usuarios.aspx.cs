using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        private PersonaLogic _logicPersona;
        private PlanLogic _logicPlan;
        private EspecialidadLogic _logicEspecialidad;
        private Dictionary<int, string> _tipoPersona;
        private Dictionary<int, string> _meses;

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
            LoadGrid();
            if(!IsPostBack)
                CargarFechas();
        }

        private Persona Entity { get; set; }
        private Plan PlanUsuario { get; set; }
        private Especialidad EspecialidadUsuario { get; set; }


        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
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
                return (SelectedID != 0);
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

            ddlAnio.DataSource = anios;
            ddlAnio.DataBind();
            ddlMes.DataSource = _meses;          
            ddlMes.DataValueField = "Key";
            ddlMes.DataTextField = "Value";
            ddlMes.DataBind();
            ddlDia.DataSource = dias;
            ddlDia.DataBind();
        }



        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }

        private void CargarTiposPersonas()
        {
            _tipoPersona = new Dictionary<int, string>();
            _tipoPersona.Add(0, "Administrativo");
            _tipoPersona.Add(1, "Docente");
            _tipoPersona.Add(2, "Alumno");
            ddlTipoPersona.DataSource = _tipoPersona;
            ddlTipoPersona.DataTextField = "Value";
            ddlTipoPersona.DataValueField = "Key";
            ddlTipoPersona.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = LogicPersona.GetOne(id);
            PlanUsuario = LogicPlan.GetOne(Entity.IdPlan);
            EspecialidadUsuario = LogicEspecialidad.GetOne(PlanUsuario.IdEspecialidad);

            txtNombre.Text = Entity.Nombre;
            txtApellido.Text = Entity.Apellido;
            txtEmail.Text = Entity.Email;
            chkHabilitado.Checked = Entity.Habilitado;
            txtNombreUsuario.Text = Entity.NombreUsuario;

            ddlAnio.SelectedValue = Entity.FechaNacimiento.Year.ToString();
            ddlMes.SelectedValue = Entity.FechaNacimiento.Month.ToString();
            ddlDia.SelectedValue = Entity.FechaNacimiento.Day.ToString();


            ddlEspecialidad.DataSource = LogicEspecialidad.GetAll().FindAll(x => x.Baja == false);
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.SelectedValue = PlanUsuario.IdEspecialidad.ToString();

            ddlIdPlan.DataSource = LogicPlan.GetAll().FindAll(x => x.Baja == false);
            ddlIdPlan.DataValueField = "ID";
            ddlIdPlan.DataTextField = "Descripcion";
            ddlIdPlan.DataBind();
            ddlIdPlan.SelectedValue = Entity.IdPlan.ToString();

            CargarTiposPersonas();
            ddlTipoPersona.SelectedIndex = (int)Entity.TipoPersona;
        }

        private void LoadEntity(Persona per)
        {
            per.Nombre = txtNombre.Text;
            per.Apellido = txtApellido.Text;
            per.Email = txtEmail.Text;
            per.NombreUsuario = txtNombreUsuario.Text;
            per.Clave = Util.Hash.SHA256ConSal(txtClave.Text, null);
            per.Habilitado = chkHabilitado.Checked;
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
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            Entity = new Persona();
            Entity.ID = SelectedID;
            Entity.State = BusinessEntity.States.Modified;
            LoadEntity(Entity);
            SaveEntity(Entity);
            LoadGrid();

            formPanel.Visible = false;
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (ddlMes.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth(int.Parse(ddlAnio.SelectedItem.Text), ddlMes.SelectedIndex + 1);


                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                ddlDia.DataSource = dias;
                ddlDia.DataBind();
            }
        }

        protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> dias = new List<int>();
            if (ddlAnio.SelectedIndex >= 0)
            {
                int diasEnMesSeleccionado = DateTime.DaysInMonth(int.Parse(ddlAnio.SelectedItem.Text), ddlMes.SelectedIndex + 1);

                for (int i = 0; i < diasEnMesSeleccionado; i++)
                {
                    dias.Add(i + 1);
                }

                ddlDia.DataSource = dias;
                ddlDia.DataBind();

            }
        }
    }
}