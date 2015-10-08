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
        private List<Plan> _planes;
        private List<Especialidad> _especialidades;

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
            Load_Grid();
        }

        private void Load_Grid()
        {
            gridComisiones.DataSource = LogicComision.GetAll();
            gridComisiones.DataBind();
        }

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

        protected void gridComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridComisiones.SelectedValue;
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
            _especialidades = LogicEspecialidades.GetAll();
            ddlEspecialidades.DataSource = _especialidades;
            ddlEspecialidades.DataValueField = "ID";
            ddlEspecialidades.DataTextField = "Descripcion";         
            ddlEspecialidades.DataBind();

        }

        private void CargarPlanes()
        {
            _planes = LogicPlanes.GetAll();
            ddlPlanes.DataSource = _planes;
            ddlPlanes.DataValueField = "ID";
            ddlPlanes.DataTextField = "Descripcion";
            ddlPlanes.DataBind();
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

        private void Load_Form(int id)
        {
            if(FormMode == FormModes.Modificacion)
            {
                txtAnioEsp.Enabled = true;
                txtDescCom.Enabled = true;
                ddlEspecialidades.Enabled = true;
                ddlPlanes.Enabled = true;
            }
            if(FormMode == FormModes.Baja)
            {
                txtAnioEsp.Enabled = false;
                txtDescCom.Enabled = false;
                ddlEspecialidades.Enabled = false;
                ddlPlanes.Enabled = false;
            }

            
            CargarEspecialidades();
            CargarPlanes();
            ComisionActual = LogicComision.GetOne(id);
            Session["Comision"] = ComisionActual;
            txtAnioEsp.Text = ComisionActual.AnioEspecialidad.ToString();
            txtDescCom.Text = ComisionActual.Descripcion;
            ddlPlanes.SelectedValue = ComisionActual.IdPlan.ToString();
            Plan p = _planes.Find(x => x.ID == ComisionActual.IdPlan);
            ddlEspecialidades.SelectedValue = _especialidades.Find(y => y.ID == p.IdEspecialidad).ID.ToString(); ;
            

        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            formActionPanel.Visible = true;
            FormMode = FormModes.Alta;
            panelFormComisiones.Visible = true;
            CargarEspecialidades();
            CargarPlanes();
            txtAnioEsp.Enabled = true;
            txtDescCom.Enabled = true;
            txtDescCom.Text = "";
            ddlEspecialidades.SelectedIndex = 0;
            ddlPlanes.SelectedIndex = 0;
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            formActionPanel.Visible = true;
            if(IsEntitySelected)
            {
                FormMode = FormModes.Modificacion;
                panelFormComisiones.Visible = true;
                Load_Form(SelectedID);
            }
        }

        protected void lnkBorrar_Click(object sender, EventArgs e)
        {
            formActionPanel.Visible = true;
            if (IsEntitySelected)
            {
                FormMode = FormModes.Baja;
                panelFormComisiones.Visible = true;
                Load_Form(SelectedID);
            }
        }

        private void CargarComision()
        {
            if (FormMode == FormModes.Alta)
            {
                ComisionActual = new Comision();
                ComisionActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                ComisionActual = (Comision)Session["Comision"];
                ComisionActual.ID = SelectedID;
                ComisionActual.State = BusinessEntity.States.Modified;

            }
            if (FormMode == FormModes.Baja)
            {
                ComisionActual.Baja = true;
            }
            else
            {
                ComisionActual.Baja = false;
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
            CargarComision();
            GuardarComision(ComisionActual);
            Load_Grid();
            SelectedID = 0;
            panelFormComisiones.Visible = false;
            formActionPanel.Visible = false;
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            panelFormComisiones.Visible = false;
            formActionPanel.Visible = false;
        }
    }
}