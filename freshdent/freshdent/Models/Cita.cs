using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Cita
    {
        public int IdCita { get; set; }
        public string FechaCita { get; set; }
        public string HoraDisponible { get; set; }
        public string Precio { get; set; }
        public string Tipo { get; set; }
        public int IdExpediente { get; set; }
        public string Nombres { get;set;}
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string Error { get; set; }
    }
}
