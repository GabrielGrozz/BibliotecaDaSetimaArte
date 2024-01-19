using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BibliotecaDaSetimaArte.Models
{
    [Table("categories")]
    public class Category
    {
        public Category()
        {
            MovieList = new Collection<Movie>();
        }

        [Key]        
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        [StringLength(128)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        [StringLength(512)]
        public string? Description { get; set; }

        public ICollection<Movie>? MovieList { get; set; }

    }
}
