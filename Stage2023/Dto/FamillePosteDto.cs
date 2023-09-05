using System.ComponentModel.DataAnnotations;

namespace Stage2023.Dto
{
    public class FamillePosteDto
    {
        [StringLength(50)]
        public string Code { get; set; } = null!;
        [StringLength(100)]
        public string Libelle { get; set; } = null!;
    }
}
