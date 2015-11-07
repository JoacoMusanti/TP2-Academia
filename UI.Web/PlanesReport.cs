using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Business.Entities;
using Business.Logic;
using System.Linq;

namespace UI.Web
{
    /// <summary>
    /// Summary description for ReportePlanes.
    /// </summary>
    public partial class PlanesReport : GrapeCity.ActiveReports.SectionReport
    {
        List<Plan> _planes;

        public PlanesReport(List<Plan> planes)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _planes = planes;
        }

        private void PlanesReport_ReportStart(object sender, EventArgs e)
        {    
            var LogicPlan = new PlanLogic();
            var LogicEspecialidad = new EspecialidadLogic();

            DataSource = _planes.Select(plan => new {
                Carrera = LogicEspecialidad.GetOne(LogicPlan.GetOne(plan.ID).IdEspecialidad).Descripcion,
                Descripcion = plan.Descripcion,
            }).ToList();
        }
    }
}
