using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
namespace Business.Logic
{
    public class CursoLogic
    {
        Data.Database.CursoAdapter CursoData { get; set; }

        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        public Curso GetOne(int ID)
        {
            try
            {
                return CursoData.GetOne(ID);
            }
            catch(Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public Curso GetOne(int mate, int comi)
        {
            try
            {
                return CursoData.GetOne(mate,comi);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public List<Curso> GetAll()
        {
             try
            {
                return CursoData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Curso curso)
        {
            try
            {
                CursoData.Save(curso);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                CursoData.Delete(ID);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }               
    }
}
