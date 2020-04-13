using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Estado
    {
        public Guid EstadoId { get; set; }
        public string UF { get; set; }
        public string NomeEstado { get; set; }

        public Estado()
        {
            EstadoId = Guid.NewGuid();
        }
    }
}