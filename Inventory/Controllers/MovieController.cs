using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory.Models;
using Inventory.ViewModel;

namespace Inventory.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;
        private MovieViewModel movieViewModel;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.movies.Include("Genre").ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var genreList = _context.genres.ToList();
            var movie = _context.movies.Include("Genre").Single(c => c.Id == Id);
            movieViewModel = new MovieViewModel()
            {
                NewMovie = movie,
                GenreList = genreList
            };

            return View("NewMovie", movieViewModel);
        }

        
        public ActionResult New()
        {
            var genreList = _context.genres.ToList();
            movieViewModel = new MovieViewModel()
            {
                GenreList = genreList,
                NewMovie = new Movie()
            };


            return View("NewMovie", movieViewModel);
        }

        [HttpPost]
        public ActionResult Save(MovieViewModel movieViewModel)
        {

            if (!ModelState.IsValid)
            {
                movieViewModel = new MovieViewModel()
                {
                    NewMovie = new Movie(),
                    GenreList = _context.genres.ToList()
                };
                return View("NewMovie", movieViewModel);
            }

            if (movieViewModel.NewMovie.Id == 0)
            {
                _context.movies.Add(movieViewModel.NewMovie);
            }
            else
            {
                var movie = _context.movies.Single(m => m.Id == movieViewModel.NewMovie.Id);
                movie.GenreId = movieViewModel.NewMovie.GenreId;
                movie.Name = movieViewModel.NewMovie.Name;
                movie.NumberInStock = movieViewModel.NewMovie.NumberInStock;
                movie.ReleaseDate = movieViewModel.NewMovie.ReleaseDate;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}