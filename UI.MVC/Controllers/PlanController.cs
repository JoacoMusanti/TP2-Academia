using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Entities;
using Business.Logic;
using UI.MVC.ViewModels;

namespace UI.MVC.Controllers
{
    public class PlanController : Controller
    {
        private PlanLogic _logicPlan;
        private EspecialidadLogic _logicEspe;

        public PlanLogic LogicPlan
        {
            get
            {
                if (_logicPlan == null)
                {
                    _logicPlan = new PlanLogic();
                }

                return _logicPlan;
            }
        }

        public EspecialidadLogic LogicEspe
        {
            get
            {
                if (_logicEspe == null)
                {
                    _logicEspe = new EspecialidadLogic();
                }

                return _logicEspe;
            }
        }

        // GET: Plan
        public ActionResult Index()
        {
            ViewBag.SelectedID = -1;

            var pes = new PlanesEspecialidadesViewModel();

            pes.Especialidades = LogicEspe.GetAll();
            pes.Planes = LogicPlan.GetAll();

            return View(pes);
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            var pe = new PlanEspecialidadesViewModel();

            pe.Especialidades = LogicEspe.GetAll();

            return View(pe);
        }

        // POST: Plan/Create
        [HttpPost]
        public ActionResult Create(PlanEspecialidadesViewModel pe)
        {
            Plan pl = pe.PlanData;

            pl.Baja = false;
            pl.State = BusinessEntity.States.New;
            pl.IdEspecialidad = pe.SelectedEspecialidad;

            LogicPlan.Save(pl);

            return RedirectToAction("Index");
        }

        // GET: Plan/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pl = LogicPlan.GetOne(id);

            var espe = LogicEspe.GetOne(pl.IdEspecialidad);

            ViewBag.Especialidad = espe.Descripcion;

            return View(pl);
        }

        // POST: Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(Plan pl)
        {
            var temp = LogicPlan.GetOne(pl.ID);

            pl.IdEspecialidad = temp.IdEspecialidad;
            pl.State = BusinessEntity.States.Modified;
            pl.Baja = false;

            LogicPlan.Save(pl);

            return RedirectToAction("Index");
        }

        // GET: Plan/Delete/5
        public ActionResult Delete(int id)
        {
            var pl = LogicPlan.GetOne(id);

            var espe = LogicEspe.GetOne(pl.IdEspecialidad);

            ViewBag.Especialidad = espe.Descripcion;

            return View(pl);
        }

        // POST: Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(Plan pl)
        {
            var temp = LogicPlan.GetOne(pl.ID);

            pl.IdEspecialidad = temp.IdEspecialidad;
            pl.Baja = false;
            pl.State = BusinessEntity.States.Deleted;

            LogicPlan.Save(pl);

            return RedirectToAction("Index");
        }
    }
}
