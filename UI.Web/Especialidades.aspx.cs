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
    public partial class Especialidades : System.Web.UI.Page
    {
        EspecialidadLogic _especialidadLogic;

        private EspecialidadLogic LogicEspecialidad
        {
            get
            {
                if (_especialidadLogic == null)
                    _especialidadLogic = new EspecialidadLogic();

                return _especialidadLogic;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if ((Persona.TipoPersonas)Session["RolSesion"] == Persona.TipoPersonas.Administrativo)
            {
                LoadGrid();
            }
            else
            {
                Response.Redirect("~/Default.aspx?mensaje=" + Server.UrlEncode("No tenes permisos para acceder a ese recurso"));
            }
        }

        private void LoadGrid()
        {
            gridEspecialidades.DataSource = LogicEspecialidad.GetAll();
            gridEspecialidades.DataBind();
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }

        private Especialidad EspActual { get; set; }

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
                return (SelectedID != -1);
            }
        }

        protected void gridEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridEspecialidades.SelectedValue;
        }

        private void LoadForm(int id)
        {
            if(FormMode == FormModes.Modificacion)
            {
                txtDescEsp.Enabled = true;  
            }
            if(FormMode == FormModes.Baja)
            {
                txtDescEsp.Enabled = false;
            }

            EspActual = LogicEspecialidad.GetOne(id);
            Session["Especialidad"] = EspActual;
            txtDescEsp.Text = EspActual.Descripcion;
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            formEspecialidadesActionPanel.Visible = true;
            if (IsEntitySelected)
            {
                FormMode = FormModes.Modificacion;
                EspecialidadesPanel.Visible = true;
                LoadForm(SelectedID);
            }
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            formEspecialidadesActionPanel.Visible = true;
            FormMode = FormModes.Alta;
            EspecialidadesPanel.Visible = true;
            txtDescEsp.Enabled = true;
            txtDescEsp.Text = "";
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            formEspecialidadesActionPanel.Visible = true;
            if (IsEntitySelected)
            {
                FormMode = FormModes.Baja;
                EspecialidadesPanel.Visible = true;
                LoadForm(SelectedID);
            }
        }

        void GuardarEspecialidad(Especialidad esp)
        {
            LogicEspecialidad.Save(esp);
        }

        private void CargarEspecialidad()
        {
            if (FormMode == FormModes.Alta)
            {
                EspActual = new Especialidad();
                EspActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                EspActual = (Especialidad)Session["Especialidad"];
                EspActual.ID = SelectedID;
                EspActual.State = BusinessEntity.States.Modified;

            }
            if (FormMode == FormModes.Baja)
            {
                EspActual.Baja = true;
            }
            else
            {
                EspActual.Baja = false;
            }

            EspActual.Descripcion = txtDescEsp.Text;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            CargarEspecialidad();
            GuardarEspecialidad(EspActual);
            LoadGrid();
            SelectedID = 0;
            EspecialidadesPanel.Visible = false;
            formEspecialidadesActionPanel.Visible = false;
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            EspecialidadesPanel.Visible = false;
            formEspecialidadesActionPanel.Visible = false;
        }
    }
}