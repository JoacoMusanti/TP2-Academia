using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter PlanData { get; set; }

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public Plan GetOne(int id)
        {
            try
            {
                return PlanData.GetOne(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Plan plan)
        {
            try
            {
                PlanData.Save(plan);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                PlanData.Delete(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
