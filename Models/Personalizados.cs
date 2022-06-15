using System;

namespace Illerons.Models
{
    public class Personalizados
    {
         public int Id {get;set;}
        public string Nome { get; set; }
         public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Roupa { get; set; }
        public string Detalhes { get; set; }
        public int Usuario {get;set;}
    }
}