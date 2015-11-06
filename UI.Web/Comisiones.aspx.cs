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
    public partial class Comisiones : System.Web.UI.Page
    {
        private ComisionLogic _logicComision;
        private EspecialidadLogic _logicEspecialidades;
        private PlanLogic _logicPlanes;

        private Comision ComisionActual { get; set; }

        public EspecialidadLogic LogicEspecialidades
        {
            get
            {
                if (_logicEspecialidades == null)
                    _logicEspecialidades = new EspecialidadLogic();
                return _logicEspecialidades;
            }
        }
        public ComisionLogic LogicComision
        {
            get
            {
                if (_logicComision == null)
                    _logicComision = new ComisionLogic();
                return _logicComision;
            }
        }

        public PlanLogic LogicPlanes
        {
            get
            {
                if (_logicPlanes == null)
                    _logicPlanes = new PlanLogic();
                return _logicPlanes;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TipoPersonas)Session["RolSesion"] == Persona.TipoPersonas.Administrativo)
            {
                CargarGrilla();
            }
            else
            {
                Response.Redirect("~/Default.aspx?mensaje=" + Server.UrlEncode("No tenes permisos para acceder a ese recurso"));
            }
            
        }

        private void CargarGrilla()
        {
            gridComisiones.DataSource = LogicComision.GetAll();
            gridComisiones.DataBind();
        }

        private int? SelectedID
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

        protected void gridComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int?)gridComisiones.SelectedValue;
            panelFormComisiones.Visible = false;
            formActionPanel.Visible = false;
            gridActionPanel.Visible = true;
        }


        enum FormModes
        {
            Alta,
            Baja,
            Modificacion
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
            ddlEspecialidades.DataSource = LogicEspecialidades.GetAll();
            ddlEspecialidades.DataValueField = "ID";
            ddlEspecialidades.DataTextField = "Descripcion";         
            ddlEspecialidades.DataBind();

        }

        private void CargarPlanes()
        {
            ddlPlanes.DataSource = LogicPlanes.GetAll();
            ddlPlanes.DataValueField = "ID";
            ddlPlanes.DataTextField = "Descripcion";
            ddlPlanes.DataBind();

            ddlEspecialidades_SelectedIndexChanged(null, null);
        }

        //private void CargarPlanes()
        //{
        //    ddlPlanes.DataSource = LogicPlanes.GetAll();
        //    ddlPlanes.DataValueField = "ID";
        //    ddlPlanes.DataTextField = "Descripcion";
        //    ddlPlanes.DataBind();
        //}

        //private void CargarEspecialidades()
        //{
        //    ddlEspecialidades.DataSource = LogicEspecialidades.GetAll();
        //    ddlEspecialidades.DataValueField = "ID";
        //    ddlEspecialidades.DataTextField = "Descripcion";
        //    ddlEspecialidades.DataBind();
        //}

        private void CargarForm(int id)
        {
            CargarEspecialidades();
            CargarPlanes();

            if (FormMode == FormModes.Baja)
            {
                txtAnioEsp.Enabled = false;
                txtDescCom.Enabled = false;
                ddlEspecialidades.Enabled = false;
                ddlPlanes.Enabled = false;
            }
            else
            {
                txtAnioEsp.Enabled = true;
                txtDescCom.Enabled = true;
                ddlEspecialidades.Enabled = true;
                ddlPlanes.Enabled = true;

                txtAnioEsp.Text = "";
                txtDescCom.Text = "";
            }
            

            if (FormMode != FormModes.Alta)
            {
                ComisionActual = LogicComision.GetOne(id);

                txtAnioEsp.Text = ComisionActual.AnioEspecialidad.ToString();
                txtDescCom.Text = ComisionActual.Descripcion;

                Plan p = LogicPlanes.GetOne(ComisionActual.IdPlan);
                ddlEspecialidades.SelectedValue = LogicEspecialidades.GetOne(p.IdEspecialidad).ID.ToString();

                ddlEspecialidades_SelectedIndexChanged(null, null);
                ddlPlanes.SelectedValue = ComisionActual.IdPlan.ToString();
                
                
            }
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Alta;
            panelFormComisiones.Visible = true;
            formActionPanel.Visible = true;
            gridActionPanel.Visible = false;

            CargarForm(SelectedID.Value);
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if(IsEntitySelected)
            {
                FormMode = FormModes.Modificacion;
                panelFormComisiones.Visible = true;
                formActionPanel.Visible = true;
                gridActionPanel.Visible = false;

                CargarForm(SelectedID.Value);
            }
        }

        protected void lnkBorrar_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                FormMode = FormModes.Baja;
                panelFormComisiones.Visible = true;
                formActionPanel.Visible = true;
                gridActionPanel.Visible = false;

                CargarForm(SelectedID.Value);
            }
        }

        private void CargarComision()
        {
            ComisionActual = new Comision();

            if (FormMode == FormModes.Alta)
            {
                ComisionActual.Baja = false;
                ComisionActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                ComisionActual.ID = SelectedID.Value;
                ComisionActual.State = BusinessEntity.States.Modified;

                if (FormMode == FormModes.Baja)
                {
                    ComisionActual.Baja = true;
                }
                else
                {
                    ComisionActual.Baja = false;
                }
            }
            

            ComisionActual.AnioEspecialidad = Convert.ToInt32(txtAnioEsp.Text);
            ComisionActual.Descripcion = txtDescCom.Text;
            ComisionActual.IdPlan= Convert.ToInt32(ddlPlanes.SelectedValue);
        }

        private void GuardarComision(Comision com)
        {
            LogicComision.Save(com);
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            panelFormComisiones.Visible = false;
            formActionPanel.Visible = false;
            gridActionPanel.Visible = true;

            CargarComision();
            GuardarComision(ComisionActual);
            CargarGrilla();

            gridComisiones.SelectedIndex = -1;
            gridComisiones_SelectedIndexChanged(null, null);
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            panelFormComisiones.Visible = false;
            formActionPanel.Visible = false;
            gridActionPanel.Visible = true;

            gridComisiones.SelectedIndex = -1;
            gridComisiones_SelectedIndexChanged(null, null);
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlanes.DataSource = LogicPlanes.GetAll().Where(plan => plan.IdEspecialidad == int.Parse(ddlEspecialidades.SelectedValue));
            ddlPlanes.DataBind();
        }
    }
}