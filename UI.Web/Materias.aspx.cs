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
            var planes = LogicPlan.GetAll();
            var especialidades = LogicEspecialidad.GetAll();
            var materias = LogicMateria.GetAll();
            // se reemplaza cada plan en planes con un objeto anonimo de la forma {ID, Descripcion, DEspecialidad}
            // donde ID es la id del plan, Descripcion es la descripcion del plan y DEspecialidad es la descripcion de la especialidad del plan
            gridMaterias.DataSource = materias.Select(mat => new { ID = mat.ID, Descripcion = mat.Descripcion, HorasSemanales = mat.HorasSemanales, HorasTotales = mat.HorasTotales, DPlan = planes.Find(pl => pl.ID == mat.IdPlan).Descripcion, DEspecialidad = especialidades.Find(esp => esp.ID == planes.Find(pl => pl.ID == mat.IdPlan).ID).Descripcion });

            gridMaterias.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGridMaterias();
        }
    }
}