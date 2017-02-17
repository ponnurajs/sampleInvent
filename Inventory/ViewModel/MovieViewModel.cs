using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.Models;

namespace Inventory.ViewModel
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> GenreList  { get; set; }
        public Movie NewMovie { get; set; }
    }
}