
using AutoMapper;
using MovieWebsite.Domain.Entities;
using MovieWebsite.Service.Interfaces;
using MovieWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            var movies = MoviesService.GetMoviesList();

            Mapper.Initialize(cfg => cfg.CreateMap<Movie, MovieViewModel>());

            return View();
        }
    }
}