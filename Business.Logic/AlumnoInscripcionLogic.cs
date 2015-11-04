using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic
    {
        private InscripcionAlumnoAdapter InscripcionData { get; set; }
        public AlumnoInscripcionLogic()
        {
            InscripcionData = new InscripcionAlumnoAdapter();
        }

        public List<AlumnoInscripcion> GetAll(int ID)
        {
            try
            {
                return InscripcionData.GetAll(ID);
            }

            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
    }
}
