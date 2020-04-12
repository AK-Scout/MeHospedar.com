using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeHospedar.Models
{
    public class Viajante
    {
        public Guid ViajanteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string Foto { get; set; }

        //public Viajante()
        //{
        //    ViajanteId = Guid.NewGuid();
        //}

    }
        
}