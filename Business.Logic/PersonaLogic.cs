﻿using System;
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
            try {

                bool validacion = true;

                if (persona.State == BusinessEntity.States.New || persona.State == BusinessEntity.States.Modified)
                {
                    if (!ValidaLegajo(persona))
                    {
                        validacion = false;
                    }
                    if (!ValidaUsuario(persona))
                    {
                        validacion = false;
                    }
                }

                if (validacion == true)
                {
                    PersonaData.Save(persona);
                }
                else
                {
                    throw new Exception("Legajo y/o nombre de usuario ya está/n en uso");
                }

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

        /// <summary>
        /// Devuelve falso si el nombre de usuario esta utilizado
        /// </summary>
        /// <param name="per"></param>
        /// <returns></returns>
        static public bool ValidaUsuario(Persona per)
        {
            bool retorno = true;
            Persona p = new PersonaLogic().GetOne(per.NombreUsuario);
            if (p.NombreUsuario != null && p.Baja == false)
            {
                if (per.ID != p.ID)
                {
                    retorno = false;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Devuelve falso si el numero de legajo esta utilizado
        /// </summary>
        /// <param name="numlegajo"></param>
        /// <returns></returns>
        static public bool ValidaLegajo(Persona per)
        {
            bool retorno = true;
            Persona p = new PersonaLogic().GetOneLeg(per.Legajo);
            if (p.Nombre != null && p.Baja == false)
            {
                if (per.ID != p.ID)
                {
                    retorno = false;
                }
            }
            return retorno;
        }

    }
}
