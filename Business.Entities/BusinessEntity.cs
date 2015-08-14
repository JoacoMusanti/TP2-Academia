using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class BusinessEntity
    {
        public enum States 
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private States _state;

        public States State
        {
            get { return _state; }
            set { _state = value; }
        }

        public BusinessEntity()
        {
            _state = States.New;
            Baja = false;
        }

        /// <summary>
        /// Establece si un objeto esta dado de baja logicamente o no
        /// </summary>
        public bool Baja { get; set; }
    }
}
