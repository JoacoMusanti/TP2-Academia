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
    public partial class Cursos : System.Web.UI.Page
    {
        private CursoLogic _logicCurso;
        private MateriaLogic _logicMateria;
        private ComisionLogic _logicComision;

        private Curso CursoActual {get; set;}

        private MateriaLogic LogicMateria
        {
            get
            {
                if(_logicMateria == null)
                {
                    _logicMateria = new MateriaLogic();
                }
                return _logicMateria;
            }
        }

        private CursoLogic LogicCurso
        {
            get 
            {
                if(_logicCurso==null)
                {
                    _logicCurso = new CursoLogic();
                }
                return _logicCurso;
            }
        }
        private ComisionLogic LogicComision
        {
            get
            {
                if (_logicComision == null)
                {
                    _logicComision = new ComisionLogic();
                }
                return _logicComision;
            }
        }

        private void LoadGrid()
        {
            CargarGridCursos();
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

        private void CargarGridCursos()
        {
            var cursos = LogicCurso.GetAll();
            gdvCursos.DataSource = cursos.Select(curso => new { ID = curso.ID,
                                                                AnioCalendario = curso.AnioCalendario,
                                                                Cupo = curso.Cupo,
                                                                Materia = LogicMateria.GetOne(curso.IdMateria).Descripcion,
                                                                Comision = LogicComision.GetOne(curso.IdComision).Descripcion });
            gdvCursos.DataBind();
        }

        private int? SelectedIDCurso
        {
            get
            {
                if (ViewState["SelectedIDCurso"] == null)
                {
                    return -1;
                }
                else
                {
                    return (int)ViewState["SelectedIDCurso"];
                }
            }
            set
            {
                ViewState["SelectedIDCurso"] = value;
            }
        }

        protected void gdvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDCurso = (int?)gdvCursos.SelectedValue;

            formPanelCurso.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;
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

        private void CargarMaterias()
        {
            ddlMaterias.DataSource = LogicMateria.GetAll();
            ddlMaterias.DataValueField = "ID";
            ddlMaterias.DataTextField = "Descripcion";
            ddlMaterias.DataBind();
        }

        private void CargarComisiones()
        {
            ddlComisiones.DataSource = LogicComision.GetAll();
            ddlComisiones.DataValueField = "ID";
            ddlComisiones.DataTextField = "Descripcion";
            ddlComisiones.DataBind();
        }
        private void CargarAnios()
        {
            List<int> anios = new List<int>(5);

            for (int i = 0; i < 5; i++)
            {
                anios.Add(DateTime.Now.Year + i);
            }

            ddlAnioCalendario.DataSource = anios;
            ddlAnioCalendario.DataBind();
        }
        private void CargarCupos()
        {
            List<int> cupos = new List<int>();

            for (int i = 20; i < 36; i++)
            {
                cupos.Add(i);
            }

            ddlCupo.DataSource = cupos;
            ddlCupo.DataBind();
        }

              
        private bool HaySeleccion()
        {
            return (SelectedIDCurso != -1);
        }

        void CargarForm(int id)
        {
            CargarMaterias();
            CargarComisiones();
            CargarAnios();
            CargarCupos();

            if (FormMode == FormModes.Baja)
            {
                ddlMaterias.Enabled = false;
                ddlComisiones.Enabled = false;
                ddlAnioCalendario.Enabled = false;
                ddlCupo.Enabled = false;
            }
            else
            {
                ddlMaterias.Enabled = true;
                ddlComisiones.Enabled = true;
                ddlAnioCalendario.Enabled = true;
                ddlCupo.Enabled = true;
            }
            if (FormMode != FormModes.Alta)
            {
                CursoActual = LogicCurso.GetOne(id);
                                               
                ddlMaterias.SelectedValue = CursoActual.IdMateria.ToString();

                ddlComisiones.SelectedValue = CursoActual.IdComision.ToString();
                ddlAnioCalendario.SelectedValue = CursoActual.AnioCalendario.ToString();
                ddlCupo.SelectedValue = CursoActual.Cupo.ToString();
            }
        }

        private void CargarCurso()
        {
            CursoActual = new Curso();

            if (FormMode == FormModes.Alta)
            {
                CursoActual.Baja = false;
                CursoActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                CursoActual.State = BusinessEntity.States.Modified;
                CursoActual.ID = SelectedIDCurso.Value;
                if (FormMode == FormModes.Baja)
                {
                    CursoActual.Baja = true;
                }
                else
                {
                    CursoActual.Baja = false;
                }
            }
          
            CursoActual.IdMateria = int.Parse(ddlMaterias.SelectedValue);
            CursoActual.IdComision = int.Parse(ddlComisiones.SelectedValue);
            CursoActual.AnioCalendario = int.Parse(ddlAnioCalendario.SelectedValue);
            CursoActual.Cupo = int.Parse(ddlCupo.SelectedValue);
        }

        private void GuardarCurso(Curso cur)
        {
            LogicCurso.Save(cur);
        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {
            FormMode = FormModes.Alta;
            formPanelCurso.Visible = true;
            formActionsPanel.Visible = true;
            gridActionsPanel.Visible = false;
           
            CargarForm(SelectedIDCurso.Value);
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
               
                FormMode = FormModes.Modificacion;
                formPanelCurso.Visible = true;
                formActionsPanel.Visible = true;
                gridActionsPanel.Visible = false;

                CargarForm(SelectedIDCurso.Value);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                FormMode = FormModes.Baja;
                formPanelCurso.Visible = true;
                formActionsPanel.Visible = true;
                gridActionsPanel.Visible = false;

                CargarForm(SelectedIDCurso.Value);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            formPanelCurso.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;

            CargarCurso();
            GuardarCurso(CursoActual);
            CargarGridCursos();

            gdvCursos.SelectedIndex = -1;
            gdvCursos_SelectedIndexChanged(null, null);            
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            formPanelCurso.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;

            gdvCursos.SelectedIndex = -1;
            gdvCursos_SelectedIndexChanged(null, null); 
        }

        protected void ddlMaterias_SelectedIndexChanged(object sender, EventArgs e)
        { 
            int idplan = LogicMateria.GetOne(int.Parse(ddlMaterias.SelectedValue)).IdPlan;
            ddlComisiones.DataSource = LogicComision.GetAll().Where(comi => comi.IdPlan == idplan);

            ddlComisiones.DataBind();
        }

        protected void ddlComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idplan = LogicComision.GetOne(int.Parse(ddlComisiones.SelectedValue)).IdPlan;
            ddlMaterias.DataSource = LogicMateria.GetAll().Where(mat => mat.IdPlan == idplan);

            ddlMaterias.DataBind();
        }
    }
}