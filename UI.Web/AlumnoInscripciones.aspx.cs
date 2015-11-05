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
    public partial class AlumnoInscripciones : System.Web.UI.Page
    {
        private AlumnoInscripcionLogic _inscripcionLogic;
        private CursoLogic _cursoLogic;
        private MateriaLogic _materiaLogic;
        private ComisionLogic _comisionLogic;

        private AlumnoInscripcion inscripcionActual { get; set; }
        
        private AlumnoInscripcionLogic InscripcionLogic
        {
            get
            {
                if (_inscripcionLogic == null)
                {
                    _inscripcionLogic = new AlumnoInscripcionLogic();
                }

                return _inscripcionLogic;
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

        private ComisionLogic LogicComision
        {
            get
            {
                if (_comisionLogic == null)
                {
                    _comisionLogic = new ComisionLogic();
                }

                return _comisionLogic;
            }
        }
        private CursoLogic LogicCurso
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }

                return _cursoLogic;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Persona.TipoPersonas)Session["RolSesion"] == Persona.TipoPersonas.Alumno)
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
            CargarGridInscripciones();
        }

        private void CargarGridInscripciones()
        {
            var inscripciones = InscripcionLogic.GetAll(Convert.ToInt32( Session["IdAlumno"]));
            
            gdvAlumno_Incripcion.DataSource = inscripciones.Select(ins => new { ID = ins.ID ,
                                                                             
                                                                            MAteria = (LogicMateria.GetOne((LogicCurso.GetOne(ins.IdCurso).IdMateria))).Descripcion,
                                                                            COmision = (LogicComision.GetOne((LogicCurso.GetOne(ins.IdCurso).IdComision))).Descripcion,
                                                                            Condicion = ins.Condicion,
                                                                            });
            gdvAlumno_Incripcion.DataBind();
        }

        private int? SelectedIDInscripcion
        {
            get
            {
                if (ViewState["SelectedIDInscripcion"] == null)
                {
                    return -1;
                }
                else
                {
                    return (int)ViewState["SelectedIDInscripcion"];
                }
            }
            set
            {
                ViewState["SelectedIDInscripcion"] = value;
            }
        }

         private bool HaySeleccion()
        {
            return (SelectedIDInscripcion != -1);
        }
         protected void gdvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDInscripcion = (int?)gdvAlumno_Incripcion.SelectedValue;

            formPanelInscripcion.Visible = false;
            formActionsPanel.Visible = false;
            gridActionsPanel.Visible = true;
        }
         enum FormModes
        {
            Alta,
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

        private void CargarInscripcion()
        {
            inscripcionActual = new AlumnoInscripcion();
            
            if (FormMode == FormModes.Alta)
            {
                inscripcionActual.Baja = false;
                inscripcionActual.State = BusinessEntity.States.New;
            }
            if (FormMode == FormModes.Baja)
            {
                inscripcionActual.State = BusinessEntity.States.Modified;
                inscripcionActual.ID = SelectedIDInscripcion.Value;

                if (FormMode == FormModes.Baja)
                {
                    inscripcionActual.Baja = true;
                }
                else
                {
                    inscripcionActual.Baja = false;
                }
            }

            inscripcionActual.IdAlumno = Convert.ToInt32(Session["IdAlumno"]);
            inscripcionActual.IdCurso =(LogicCurso.GetOne(int.Parse(ddlMaterias.SelectedValue),int.Parse(ddlComisiones.SelectedValue))).IdCurso;
            inscripcionActual.Condicion = "Inscripto";
                       
       }

        private void CargarForm(int id)
        {
            CargarMaterias();
            CargarComisiones();

            if (FormMode == FormModes.Baja)
            {
                ddlMaterias.Enabled = false;
                ddlComisiones.Enabled = false;
            }
            else
            {

                ddlMaterias.Enabled = true;
                ddlComisiones.Enabled = true;
                                
            }

            if (FormMode != FormModes.Alta)
            {
                inscripcionActual = InscripcionLogic.GetOne(id);

                
                //ddlPlan.SelectedValue = MateriaActual.IdPlan.ToString();
                //ddlEspecialidad.SelectedValue = LogicEspecialidad.GetAll().Find(esp => esp.ID == LogicPlan.GetOne(MateriaActual.IdPlan).IdEspecialidad).ID.ToString();
            }
        }

        private void GuardarInscripcion(AlumnoInscripcion alumIns)
        {
            InscripcionLogic.Save(alumIns);
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void lnkAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void lnkNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}