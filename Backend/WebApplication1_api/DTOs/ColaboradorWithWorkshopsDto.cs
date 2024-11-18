using System.Collections.Generic;

namespace WebApplication1_api.Dtos
{
    public class ColaboradorWithWorkshopsDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<WorkshopDto> Workshops { get; set; } = new List<WorkshopDto>();
    }
}
    