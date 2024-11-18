using System;
using System.Collections.Generic;

namespace WebApplication1_api.Dtos
{
    public class WorkshopWithColaboradoresDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public List<ColaboradorDto> Colaboradores { get; set; } = new List<ColaboradorDto>();
    }
}
