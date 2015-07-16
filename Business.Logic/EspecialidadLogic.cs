using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter EspecialidadData { get; set; }

        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public Especialidad GetOne(int id)
        {
            try
            {
                return EspecialidadData.GetOne(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Especialidad esp)
        {
            try
            {
                EspecialidadData.Save(esp);
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
                EspecialidadData.Delete(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
