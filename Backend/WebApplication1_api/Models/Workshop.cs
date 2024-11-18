using System;
using System.Collections.Generic;

namespace WebApplication1_api.Models
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public ICollection<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();
    }
}
