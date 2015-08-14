using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        Data.Database.PersonaAdapter PersonaData {get; set; }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            try
            {
                return PersonaData.GetOne(ID);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public Persona GetOne(string nameuser)
        {
            try
            {
                return PersonaData.GetOne(nameuser);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
        public Persona GetOneLeg(int legajo)
        {
            try
            {
                return PersonaData.GetOneLeg(legajo);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
        
    
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Persona persona)
        {
            try
            {
                PersonaData.Save(persona);
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
                PersonaData.Delete(ID);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        static public bool ValidaUsuario(string nombreUsu)
        {  
            bool retorno = true;
            Persona p = new PersonaLogic().GetOne(nombreUsu);
            if (p.NombreUsuario != null)
            {
                retorno = false;
            }
            return retorno;
        }
        // Este metodo valida que el legajo ya no esté utilizado
        static public bool ValidaLegajo(int numlegajo)
        {   
            bool retorno = true;
            Persona p = new PersonaLogic().GetOneLeg(numlegajo);
            if (p.Nombre != null)
            {
                retorno = false;
            }
            return retorno;
        }


    }
}
