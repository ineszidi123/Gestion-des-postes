using System.ComponentModel.DataAnnotations;

namespace Stage2023.Dto
{
    public class TypePosteDto
    {
        [StringLength(50)]
        public string Code { get; set; } = null!;
        [StringLength(100)]
        public string Libelle { get; set; } = null!;
        [StringLength(200)]
        public string? Description { get; set; }

        public long? IdFamilleposteFK { get; set; }
    }
}
