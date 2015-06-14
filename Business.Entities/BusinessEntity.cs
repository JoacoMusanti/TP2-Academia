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
        private States _Estado;

        public States Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public BusinessEntity()
        {
            this._Estado = States.New;
        }

    }
}
