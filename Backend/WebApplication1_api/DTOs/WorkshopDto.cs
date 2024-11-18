using System;
using System.Collections.Generic;

namespace WebApplication1_api.Dtos
{
    public class WorkshopDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public List<int> ColaboradoresIds { get; set; } = new List<int>();
    }
}
