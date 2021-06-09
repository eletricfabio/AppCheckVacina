using System;
using System.Collections.Generic;
using System.Text;

namespace AppCheckVacina.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public string Febre { get; set; }

        public string DordeCab { get; set; }

        public string FaltadeAr { get; set; }
    }
}
