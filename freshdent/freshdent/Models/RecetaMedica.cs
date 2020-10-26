using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace freshdent.Models
{
    public class RecetaMedica
    {
        //Se definieron los atributos junto con sus propiedades tal como se encuentra en la tabla Receta de la base de datos.
        public int IdReceta { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
    }
}
