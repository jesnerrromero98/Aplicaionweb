using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Sintoma { get; set; }
        public string Diagnostico { get; set; }
        public int IdExpediente { get; set; }
        public int IdMedico { get; set; }
        //Agreamos este campo con el fin de presentarlo en el data grid
        //si deseamos presentar mas campos en el datagrid debemos agregarlos aca
        //realizar la consulta en sql correctamente y configurar la capa de datos
        public string NombreMedico { get; set; }
        public string Nombres { get; set; }
    }
}
