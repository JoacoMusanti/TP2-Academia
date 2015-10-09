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
    public partial class Cursos : System.Web.UI.Page
    {
        private CursoLogic _logicCurso;
        private MateriaLogic _logicMateria;
        private ComisionLogic _logicComision;

        private Curso CursoActual
        {
            get; set;
        }

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
            LoadGrid();
            if (!Page.IsPostBack)
            {
                SelectedIDCurso = -1;
                lnkAceptar.Enabled = false;
                gdvCursos.EnablePersistedSelection = false;
            }
        }

        private void CargarGridCursos()
        {
            var cursos = LogicCurso.GetAll();
            var materias = LogicMateria.GetAll();
            var comisiones = LogicComision.GetAll();
            gdvCursos.DataSource = cursos.Select(curso => new { ID = curso.ID, AnioCalendario = curso.AnioCalendario, Cupo = curso.Cupo,
                Materia = materias.Find(mat => curso.IdMateria == mat.ID).Descripcion, Comision = comisiones.Find(com => curso.IdComision == com.ID).Descripcion });

            gdvCursos.DataBind();
        }

        private int SelectedIDCurso
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
            SelectedIDCurso = (int)gdvCursos.SelectedValue;
            formPanelCurso.Visible = false;
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
            List<int> anios = new List<int>(100);

            for (int i = 0; i < 100; i++)
            {
                anios.Add(DateTime.Now.Year - i);
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
            if (FormMode == FormModes.Baja)
            {
                ddlMaterias.Enabled = false;
                ddlComisiones.Enabled = false;
                ddlAnioCalendario.Enabled = false;
                ddlCupo.Enabled = false;
            }
            if (FormMode == FormModes.Modificacion)
            {
                ddlMaterias.Enabled = true;
                ddlComisiones.Enabled = true;
                ddlAnioCalendario.Enabled = true;
                ddlCupo.Enabled = true;
            }

            CargarMaterias();
            CargarComisiones();
            CargarAnios();
            CargarCupos();

            CursoActual = LogicCurso.GetOne(id);
            Session["Curso"] = CursoActual;
            ddlMaterias.SelectedValue = CursoActual.IdMateria.ToString();
            ddlComisiones.SelectedValue = CursoActual.IdComision.ToString();
            ddlAnioCalendario.SelectedValue = CursoActual.AnioCalendario.ToString();
            ddlCupo.SelectedValue = CursoActual.Cupo.ToString();
            
        }

        private void CargarCurso()
        {
            if (FormMode == FormModes.Alta)
            {
                CursoActual = new Curso();
                CursoActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja || FormMode == FormModes.Modificacion)
            {
                CursoActual = (Curso)Session["Curso"];
                CursoActual.ID = SelectedIDCurso;
                CursoActual.State = BusinessEntity.States.Modified;

            }
            if (FormMode == FormModes.Baja)
            {
                CursoActual.Baja = true;
            }
            else
            {
                CursoActual.Baja = false;
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
            lnkAceptar.Enabled = true;
            FormMode = FormModes.Alta;
            formPanelCurso.Visible = true;
            CargarMaterias();
            CargarComisiones();
            CargarAnios();
            CargarCupos();
            ddlMaterias.Enabled = true;
            ddlComisiones.Enabled = true;
            ddlAnioCalendario.Enabled = true;
            ddlCupo.Enabled = true;

            ddlMaterias.SelectedIndex = 0;
            ddlComisiones.SelectedIndex = 0;
            ddlAnioCalendario.SelectedIndex = 0;
            ddlCupo.SelectedIndex = 0;
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                lnkAceptar.Enabled = true;
                FormMode = FormModes.Modificacion;

                formPanelCurso.Visible = true;
                CargarForm(SelectedIDCurso);
            }
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (HaySeleccion())
            {
                lnkAceptar.Enabled = true;
                FormMode = FormModes.Baja;

                formPanelCurso.Visible = true;
                CargarForm(SelectedIDCurso);
            }
        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {
            if (lnkAceptar.Enabled)
            {
                CargarCurso();
                GuardarCurso(CursoActual);
                CargarGridCursos();
                SelectedIDCurso = -1;
                formPanelCurso.Visible = false;
                lnkAceptar.Enabled = false;
            }

        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            formPanelCurso.Visible = false;
            SelectedIDCurso = -1;

        }
    }
}