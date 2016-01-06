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
                var espe = EspecialidadData.GetOne(id);

                if (espe != null)
                {
                    return espe;
                }
                else
                {
                    throw new Exception("Error al recuperar la especialidad de la base de datos");
                }
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
