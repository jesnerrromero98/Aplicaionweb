using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace freshdent.Models
{
    public class Expediente
    {

        public int IdExpediente { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public int Telefono_Celular { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }

        public string Error { get; set; }
    }
}
