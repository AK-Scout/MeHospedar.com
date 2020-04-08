using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MeHospedar.Models
{
    public class Viajante
    {
       
        public int ViajanteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }

        public int ImagemId { get; set; }
        public Imagem Imagem { get; set; }
    }

    
}