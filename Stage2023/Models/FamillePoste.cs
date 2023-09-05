using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Stage2023.Models
{
    public class FamillePoste
    {
        [Key]
        public long id { get; set; }

 
        public string Code { get; set; } = null!;

        public string Libelle { get; set; } = null!;
        public virtual ICollection<TypePoste> Typepostes { get; set; } = new Collection<TypePoste>();
        public FamillePoste()
        {
            
        }
        public FamillePoste(string code, string libelle)
        {
            
            Code = code;
            Libelle = libelle;
           
        }
    }
}
