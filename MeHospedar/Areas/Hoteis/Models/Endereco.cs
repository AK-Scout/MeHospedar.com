using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Endereco
    {
        public Guid EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public Cidade Cidade { get; set; }

        public Endereco()
        {
            EnderecoId = Guid.NewGuid();
        }
    }
}