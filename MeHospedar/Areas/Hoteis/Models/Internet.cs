using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Internet
    {
        public Guid InternetId { get; set; }
        public float Valor { get; set; }
        public string Tipo { get; set; }
        public string Abrangencia { get; set; }
    }
}