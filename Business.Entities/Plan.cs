﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    class Plan : BusinessEntity
    {
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }

    }
}
