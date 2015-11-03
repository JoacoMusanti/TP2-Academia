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
    public partial class Materias : System.Web.UI.Page
    {
        private PlanLogic _planLogic;
        private EspecialidadLogic _especialidadLogic;
        private MateriaLogic _materiaLogic;

        private Materia MateriaActual { get; set; }

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
        private MateriaLogic LogicMateria
        {
            get
            {
                if (_materiaLogic == null)
                {
                    _materiaLogic = new MateriaLogic(); 
                }

                return _materiaLogic;
            }
        }

        private void CargarGridMaterias()
        {
            var materias = LogicMateria.GetAll();

            // se reemplaza cada plan en planes con un objeto anonimo de la forma {ID, Descripcion, DEspecialidad}
            // donde ID es la id del plan, Descripcion es la descripcion del plan y DEspecialidad es la descripcion de la especialidad del plan
            gridMaterias.DataSource = materias.Select(mat => new { ID = mat.ID,
                                                                   Descripcion = mat.Descripcion,
                                                                   HorasSemanales = mat.HorasSemanales,
                                                                   HorasTotales = mat.HorasTotales,
                                                                   DPlan = LogicPlan.GetOne(mat.IdPlan).Descripcion,
                                                                   DEspecialidad = LogicEspecialidad.GetOne(LogicPlan.GetOne(mat.IdPlan).IdEspecialidad).Descripcion });

            gridMaterias.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TipoPersonas)Session["RolSesion"] == Persona.TipoPersonas.Administrativo)
            {
                CargarGridMaterias();
            }
            else
            {
                Response.Redirect("~/Default.aspx?mensaje=" + Server.UrlEncode("No tenes permisos para acceder a ese recurso"));
            }
            
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

        private bool HaySeleccion()
        {
            return (SelectedID != -1);
        }
        private void CargarPlanes()
        {
            ddlPlan.DataSource = LogicPlan.GetAll();
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataBind();
        }

        private void CargarEspecialidades()
        {
            ddlEspecialidad.DataSource = LogicEspecialidad.GetAll();
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataBind();
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

        private void CargarMateria()
        {
            MateriaActual = new Materia();

            if (FormMode == FormModes.Alta)
            {
                MateriaActual.Baja = false;
                MateriaActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                MateriaActual.State = BusinessEntity.States.Modified;
                MateriaActual.ID = SelectedID.Value;

                if (FormMode == FormModes.Baja)
                {
                    MateriaActual.Baja = true;
                }
                else
                {
                    MateriaActual.Baja = false;
                }
            }

            MateriaActual.Descripcion = txtDescripcion.Text;
            MateriaActual.HorasSemanales = int.Parse(txtHorasSemanales.Text);
            MateriaActual.HorasTotales = int.Parse(txtHorasTotales.Text);
            MateriaActual.IdPlan = int.Parse(ddlPlan.SelectedValue);
        }

        private void GuardarMateria(Materia mat)
        {
            LogicMateria.Save(mat);
        }

        private void CargarForm(int id)
        {
            CargarEspecialidades();
            CargarPlanes();

            if (FormMode == FormModes.Baja)
            {
                txtDescripcion.Enabled = false;
                txtHorasSemanales.Enabled = false;
                txtHorasTotales.Enabled = false;
                ddlEspecialidad.Enabled = false;
                ddlPlan.Enabled = false;
            }
            else
            {
                txtDescripcion.Enabled = true;
                txtHorasSemanales.Enabled = true;
                txtHorasTotales.Enabled = true;
                ddlEspecialidad.Enabled = true;
                ddlPlan.Enabled = true;

                txtDescripcion.Text = "";
                txtHorasTotales.Text = "";
                txtHorasSemanales.Text = "";
            }

            if (FormMode != FormModes.Alta)
            {
                MateriaActual = LogicMateria.GetOne(id);

                txtDescripcion.Text = MateriaActual.Descripcion;
                txtHorasSemanales.Text = MateriaActual.HorasSemanales.ToString();
                txtHorasTotales.Text = MateriaActual.HorasTotales.ToString();

                ddlPlan.SelectedValue = MateriaActual.IdPlan.ToString();
                ddlEspecialidad.SelectedValue = LogicEspecialidad.GetAll().Find(esp => esp.ID == LogicPlan.GetOne(MateriaActual.IdPlan).IdEspecialidad).ID.ToString();
            }
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Alta;
            materiasPanel.Visible = true;
            formActionPanel.Visible = true;
            gridMateriasActionPanel.Visible = false;

            CargarForm(SelectedID.Value);
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                FormMode = FormModes.Modificacion;
                materiasPanel.Visible = true;
                formActionPanel.Visible = true;
                gridMateriasActionPanel.Visible = false;

                CargarForm(SelectedID.Value); 
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                FormMode = FormModes.Baja;
                materiasPanel.Visible = true;
                formActionPanel.Visible = true;
                gridMateriasActionPanel.Visible = false;

                CargarForm(SelectedID.Value); 
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            materiasPanel.Visible = false;
            formActionPanel.Visible = false;
            gridMateriasActionPanel.Visible = true;

            CargarMateria();
            GuardarMateria(MateriaActual);
            CargarGridMaterias();

            gridMaterias.SelectedIndex = -1;
            gridMaterias_SelectedIndexChanged(null, null);
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            materiasPanel.Visible = false;
            formActionPanel.Visible = false;
            gridMateriasActionPanel.Visible = true;

            gridMaterias.SelectedIndex = -1;
            gridMaterias_SelectedIndexChanged(null, null);
        }

        protected void gridMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int?)gridMaterias.SelectedValue;
            materiasPanel.Visible = false;
            formActionPanel.Visible = false;
            gridMateriasActionPanel.Visible = true;
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPlan.DataSource = LogicPlan.GetAll().Where(plan => plan.IdEspecialidad == int.Parse(ddlEspecialidad.SelectedValue));
            ddlPlan.DataBind();
        }
    }
}