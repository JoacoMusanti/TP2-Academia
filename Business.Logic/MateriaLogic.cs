using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic:BusinessLogic
    {
        private MateriaAdapter MateriaData {get;set;}

        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Materia GetOne(int id)
        {
            try
            {
                return MateriaData.GetOne(id);   
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public List<Materia> GetAll()
        {
            try
            {
               return MateriaData.GetAll();
            }

            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Materia materia)
        {
            try
            {
                MateriaData.Save(materia);
            }

            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Delete(Materia mat)
        {
            try
            {
                MateriaData.Delete(mat);
            }
            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
