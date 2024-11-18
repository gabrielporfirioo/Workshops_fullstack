using System.Collections.Generic;

namespace WebApplication1_api.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public ICollection<Workshop> Workshops { get; set; } = new List<Workshop>();
    }
}
