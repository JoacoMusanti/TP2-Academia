using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class PlanesMaterias : System.Web.UI.Page
    {
        private PlanLogic _planLogic;
        private EspecialidadLogic _especialidadLogic;

        private Plan PlanActual
        {
            get; set;
        }

        private PlanLogic LogicPlan
        {
            get
            {
                if (_planLogic == null)
                {
                    _planLogic = new PlanLogic();
                }

                return _planLogic;
            }
        }
        private EspecialidadLogic LogicEspecialidad
        {
            get
            {
                if (_especialidadLogic == null)
                {
                    _especialidadLogic = new EspecialidadLogic();
                }

                return _especialidadLogic;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGridPlanes();
            

            if (!Page.IsPostBack)
            {
                SelectedID = -1;
            }
        }

        private void CargarGridPlanes()
        {
            var planes = LogicPlan.GetAll();
            // se reemplaza cada plan en planes con un objeto anonimo de la forma {ID, Descripcion, DEspecialidad}
            // donde ID es la id del plan, Descripcion es la descripcion del plan y DEspecialidad es la descripcion de la especialidad del plan
            gridPlanes.DataSource = planes.Select(plan => new { ID = plan.ID, Descripcion = plan.Descripcion, DEspecialidad = LogicEspecialidad.GetOne(plan.IdEspecialidad).Descripcion });
            
            gridPlanes.DataBind();
        }

        private int? SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] == null)
                {
                    return -1;
                }
                else
                {
                    return (int)ViewState["SelectedID"];
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }

        protected void gridPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int?)gridPlanes.SelectedValue;
            planesPanel.Visible = false;
            formActionPanel.Visible = false;
            gridPlanesActionPanel.Visible = true;
        }

        enum FormModes
        {
            Alta,
            Modificacion,
            Baja,
        }

        FormModes FormMode
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

        private void CargarEspecialidades()
        {
            ddlEspecialidades.DataSource = LogicEspecialidad.GetAll();
            ddlEspecialidades.DataValueField = "ID";
            ddlEspecialidades.DataTextField = "Descripcion";
            ddlEspecialidades.DataBind();
        }

        private bool HaySeleccion()
        {
            return (SelectedID != -1);
        }

        void CargarForm(int id)
        {
            if (FormMode == FormModes.Baja)
            {
                txtDescripcion.Enabled = false;
                ddlEspecialidades.Enabled = false;
            }
            if (FormMode == FormModes.Modificacion)
            {
                txtDescripcion.Enabled = true;
                ddlEspecialidades.Enabled = true;
            }

            CargarEspecialidades();

            PlanActual = LogicPlan.GetOne(id);
            Session["Plan"] = PlanActual;
            txtDescripcion.Text = PlanActual.Descripcion;
            ddlEspecialidades.SelectedValue = PlanActual.IdEspecialidad.ToString();
        
            
        }

        private void  CargarPlan()
        { 
            if (FormMode == FormModes.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja ||FormMode == FormModes.Modificacion)
            {
                PlanActual = (Plan)Session["Plan"];
                PlanActual.State = BusinessEntity.States.Modified;
            }

            if (FormMode == FormModes.Baja)
            {
                PlanActual.Baja = true;
            }
            else
            {
                PlanActual.Baja = false;
            }

            PlanActual.Descripcion = txtDescripcion.Text;
            PlanActual.IdEspecialidad = int.Parse(ddlEspecialidades.SelectedValue);
        }

        private void GuardarPlan(Plan pa)
        {
            LogicPlan.Save(pa);
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Alta;
            planesPanel.Visible = true;
            formActionPanel.Visible = true;
            gridPlanesActionPanel.Visible = false;

            CargarEspecialidades();
            txtDescripcion.Enabled = true;
            ddlEspecialidades.Enabled = true;

            txtDescripcion.Text = "";
            ddlEspecialidades.SelectedIndex = 0;
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                FormMode = FormModes.Modificacion;
                planesPanel.Visible = true;
                formActionPanel.Visible = true;
                gridPlanesActionPanel.Visible = false;

                CargarForm(SelectedID.Value);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                planesPanel.Visible = true;
                formActionPanel.Visible = true;
                gridPlanesActionPanel.Visible = false;
                FormMode = FormModes.Baja;
                
                CargarForm(SelectedID.Value);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            CargarPlan();
            GuardarPlan(PlanActual);
            CargarGridPlanes();
            formActionPanel.Visible = false;
            planesPanel.Visible = false;
            gridPlanesActionPanel.Visible = true;
                

            gridPlanes.SelectedIndex = -1;
            gridPlanes_SelectedIndexChanged(null, null);
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            planesPanel.Visible = false;
            formActionPanel.Visible = false;
            gridPlanesActionPanel.Visible = true;

            gridPlanes.SelectedIndex = -1;
            gridPlanes_SelectedIndexChanged(null, null);
            
        }
    }
}