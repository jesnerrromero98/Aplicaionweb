using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class ConsMedExp
    {
        public int IdConsulta { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Sintoma { get; set; }
        public string Diagnostico { get; set; }
        public int IdExpediente { get; set; }
        public string Nombres { get; set; }
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
    }
}
