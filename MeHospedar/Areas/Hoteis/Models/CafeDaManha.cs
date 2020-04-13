using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class CafeDaManha
    {
        public Guid CafeDaManhaId {get; set;}
        public string Tipo { get; set; } //americano, alemão, etc..
        public char Incluso { get; set; }// S/N
        public float Valor { get; set; }

    }
}