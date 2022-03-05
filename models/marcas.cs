using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019AM606WACRUD.models
{
    public class marcas
        
    {

        [Key]
        public int id_marca { get; set; }
        public string nombre_marca { get; set; }
        public char estados { get; set; }

    }
}
