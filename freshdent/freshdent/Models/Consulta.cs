using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Sintoma { get; set; }
        public string Diagnostico { get; set; }
        public int IdExpediente { get; set; }
        public string Nombres { get; set; } //Tabla Expediente
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; } //Tabla Medico
        public string Error { get; set; }
    }
}
