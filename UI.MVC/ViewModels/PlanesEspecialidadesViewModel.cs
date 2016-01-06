using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Entities;

namespace UI.MVC.ViewModels
{
    public class PlanesEspecialidadesViewModel
    {
        public List<Plan> Planes { get; set; }
        public List<Especialidad> Especialidades { get; set; }
    }
}