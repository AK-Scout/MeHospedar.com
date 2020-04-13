using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Cidade
    {
        public Guid CidadeId  {get; set;}
        public string NomeCidade { get; set; }
        public Estado Estado { get; set; }

        public Cidade()
        {
            CidadeId = Guid.NewGuid();
        }
    }
}