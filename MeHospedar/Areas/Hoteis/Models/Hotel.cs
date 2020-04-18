using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeHospedar.Areas.Hoteis.Models
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Nome { get; set; }
        public string NomeContato { get; set; }
        public string Telefone { get; set; }
        public int Estrelas { get; set; }
        public int numero { get; set; }  // Marchi
        public Guid EnderecoId { get; set; }
        public Guid EstruturaId { get; set; }
        public Guid IdiomaId {get;set;}
      //  public Guid PoliticaId { get; set; }
        
        public Endereco Endereco { get; set; }
        public Estrutura Estrutura { get; set; }
        public Idioma Idioma { get; set; }

        public List<CafeDaManha> CafeDaManha {get; set;}
    }
}