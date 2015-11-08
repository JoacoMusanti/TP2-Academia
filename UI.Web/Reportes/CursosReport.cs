using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Business.Entities;
using System.Linq;
using Business.Logic;

namespace UI.Web
{
    /// <summary>
    /// Summary description for CursosReport.
    /// </summary>
    public partial class CursosReport : GrapeCity.ActiveReports.SectionReport
    {
        private List<Curso> _cursos;

        public CursosReport(List<Curso> cursos)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _cursos = cursos;
        }

        private void CursosReport_ReportStart(object sender, EventArgs e)
        {
            try
            {
                var LogicMateria = new MateriaLogic();
                var LogicComision = new ComisionLogic();
                var LogicPlan = new PlanLogic();
                var LogicEspecialidad = new EspecialidadLogic();

                DataSource = _cursos.Select(curso => new
                {
                    Carrera = LogicEspecialidad.GetOne(LogicPlan.GetOne(LogicMateria.GetOne(curso.IdMateria).IdPlan).IdEspecialidad).Descripcion,
                    Anio = curso.AnioCalendario,
                    Cupo = curso.Cupo,
                    Materia = LogicMateria.GetOne(curso.IdMateria).Descripcion,
                    Comision = LogicComision.GetOne(curso.IdComision).Descripcion
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
