using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public Genre genre { get; set; }
        public int GenreId { get; set; }

        [Range(1, 20, ErrorMessage ="NumberInStock should be 1 and 20")]
        public int NumberInStock { get; set; }
    }
}