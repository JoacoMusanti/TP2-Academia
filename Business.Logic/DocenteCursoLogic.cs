using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        private docenteCursoAdapter DocenteCursoData { get; set; }
        public DocenteCursoLogic()
        {
            DocenteCursoData = new docenteCursoAdapter();
        }

        public List<docenteCursos> GetAll(int ID)
        {
            try
            {
                return DocenteCursoData.GetAll(ID);
            }

            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public docenteCursos GetOne(int id)
        {
            try
            {
                return DocenteCursoData.GetOne(id);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
