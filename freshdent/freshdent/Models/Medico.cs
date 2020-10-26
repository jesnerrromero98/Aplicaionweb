using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Medico
    {
        //Se definieron los atributos junto con sus propiedades tal como se encuentra en la tabla Médico de la base de datos.
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public int Telefono_Celular { get; set; }
        
    }
}
