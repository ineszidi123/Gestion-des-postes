using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Stage2023.Models
{
    public class TypePoste
    {
        [Key]
        public long id { get; set; }
        public string Code { get; set; } = null!;

        public string Libelle { get; set; } = null!;

        public string? Description { get; set; }
        
        public long? IdFamilleposteFK { get; set; }
        public FamillePoste famillePoste { get; set; }    
        public virtual ICollection<Poste> postes { get; set; } = new Collection<Poste>();

       
        public TypePoste()
        {
            
        }
        public TypePoste( string code, string libelle, string? description, long? idFamilleposteFK)
        {
            Code = code;
            Libelle = libelle;
            Description = description;
            IdFamilleposteFK = idFamilleposteFK;
            
            
        }
        public class CountPoste
        {
            public string TypePoste { get; set; }
            public int NombrePostes { get; set; }
        }

    }
}
