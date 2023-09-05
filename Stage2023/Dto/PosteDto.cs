using System.ComponentModel.DataAnnotations;

namespace Stage2023.Dto
{
    public class PosteDto
    {

        public long IdTypeposteFK { get; set; }
        public string Nomreseau { get; set; } = null!;

        public string Libelle { get; set; } = null!;

        public bool Actif { get; set; } 
       


    }
}
