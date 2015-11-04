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
    public partial class AlumnoInscripcion : System.Web.UI.Page
    {
        private AlumnoInscripcionLogic _inscripcionLogic;
        private CursoLogic _cursoLogic;
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
                CargarGridInscripciones();
            }
            else
            {
                Response.Redirect("~/Default.aspx?mensaje=" + Server.UrlEncode("No tenes permisos para acceder a ese recurso"));
            }
            
        }

        private void CargarGridInscripciones()
        {
            var inscripciones = InscripcionLogic.GetAll(Convert.ToInt32( Session["IdAlumno"]));
            gdvAlumno_Incripcion.DataSource = inscripciones.Select(ins => new { ID = ins.ID ,
                                                                            CUrso = ins.IdCurso,
                                                                            Condicion = ins.Condicion,
                                                                            Nota = ins.Nota});
            gdvAlumno_Incripcion.DataBind();
        }
    }
}