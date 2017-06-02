
using AutoMapper;
using MovieWebsite.Domain.Entities;
using MovieWebsite.Service.Interfaces;
using MovieWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;

namespace MovieWebsite.Controllers
{
    public class HomeController : Controller
    {
        IMoviesService MoviesService;

        public HomeController(IMoviesService moviesService)
        {
            MoviesService = moviesService;
        }

        // GET: Home
        public ActionResult Index(MovieListViewModel viewModel, string orderBy, int? pageNum)
        {
            MovieListViewModel outViewModel = new MovieListViewModel()
            {
                OrderBy = (String.IsNullOrEmpty(orderBy)) ? "asc" : orderBy,
                SearchString = (viewModel != null) ? (viewModel.SearchString ?? "") : "",
                FilterBy = (viewModel != null) ? (viewModel.FilterBy ?? "Title") : "Title",
            };

            IEnumerable<Movie> movies = new List<Movie>(MoviesService.GetMoviesList(
                outViewModel.SearchString, outViewModel.FilterBy, outViewModel.OrderBy ?? "asc"));

            ICollection<MovieListItemModel> moviesToView = new List<MovieListItemModel>();

            foreach(var curMovie in movies)
            {
                moviesToView.Add(MapMovieToView(curMovie));
            }

            outViewModel.Movies = moviesToView.ToPagedList(pageNum ?? 1, 2);

            return View(outViewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(MapMovieToView(MoviesService.GetMovie(id)));
        }

        MovieListItemModel MapMovieToView(Movie movie)
        {
            return new MovieListItemModel()
            {
                ID = movie.ID,

                Title = movie.Title,

                Actors = movie.Actors.Select(
                        a => (new ActorViewModel()
                        {
                            FullName = a.FirstName + " " + a.LastName
                        })).ToList(),

                Genres = movie.Genres.Select(
                        g => (new GenreViewModel()
                        {
                            Name = g.Name
                        })).ToList(),

                Description = movie.Description                        
            };
        }
    }
}