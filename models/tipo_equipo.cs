using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019AM606WACRUD.models
{
    public class tipo_equipo
    {

        [Key]
        public int id_tipo_equipo { get; set; }

        public string descripcion { get; set; }

        public char estado { get; set; }
    }
}
