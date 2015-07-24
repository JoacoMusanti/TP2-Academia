using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter ComisionData { get; set; }

        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Comision GetOne(int id)
        {
            try
            {
                return ComisionData.GetOne(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Comision comi)
        {
            try
            {
                ComisionData.Save(comi);
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
                ComisionData.Delete(id);
            }
            catch (Exception e) 
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
