using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string Telefono_Celular { get; set; }
        public int IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
        public string Error { get; set; }
        
    }
}
