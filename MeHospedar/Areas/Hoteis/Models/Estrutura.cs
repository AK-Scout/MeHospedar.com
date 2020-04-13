using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Estrutura
    {
        public Guid EstruturaId { get; set; }
        public char Estacionamento {get; set;}
        public Guid InternetId { get; set; }

        public Internet internet { get; set; }
    }
}