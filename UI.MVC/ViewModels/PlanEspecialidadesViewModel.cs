using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Entities;

namespace UI.MVC.ViewModels
{
    public class PlanEspecialidadesViewModel
    {
        public Plan PlanData { get; set; }
        public int SelectedEspecialidad { get; set; }
        public List<Especialidad> Especialidades { get; set; } 
    }
}