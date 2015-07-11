using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic:BusinessLogic
    {
        Data.Database.UsuarioAdapter UsuarioData {get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        public Usuario GetOne(int ID)
        {
            try
            {
                return UsuarioData.GetOne(ID);
            }
            catch (Exception e)
            {
                // debe realizarse un log de la excepcion
                throw;
            }
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();
            }
            catch (Exception e)
            {
                // debe realizarse un log de la excepcion
                throw;
            }
        }

        public void Save(Usuario usuario)
        {
            try
            {
                UsuarioData.Save(usuario);
            }
            catch (Exception e)
            {
                // debe realizarse un log de la excepcion
                throw;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                UsuarioData.Delete(ID);
            }
            catch (Exception e)
            {
                // debe realizarse un log de la excepcion
                throw;
            }
        }
    }
}
