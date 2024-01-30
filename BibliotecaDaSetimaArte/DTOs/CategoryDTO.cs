using BibliotecaDaSetimaArte.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BibliotecaDaSetimaArte.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public ICollection<MovieDTO>? MovieList { get; set; }
    }
}
