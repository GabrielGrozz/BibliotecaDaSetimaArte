using BibliotecaDaSetimaArte.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaDaSetimaArte.Models
{
    [Table("movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Informe o nome do filme")]
        [Display(Name = "Nome")]
        [StringLength(128)]
        [FirstLetter]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe o sinopse do filme")]
        [Display(Name = "Sinopse")]
        [StringLength(512)]
        public string? Synopsis { get; set;}

        [Required(ErrorMessage = "Informe a data de lançamento do filme")]
        [Display(Name = "Data de lançamento")]
        public int? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Informe a URL da imagem do filme")]
        [Display(Name = "Imagem")]
        [StringLength(512)]
        public string? ImageURL { get; set; }
                
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


    }    
}
