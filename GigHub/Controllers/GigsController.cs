using System;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == userId);
            var genre = _context.Genres.Single(g => g.Id == model.Genre);
            //var nextId = (_context.Gigs.Select(g => g.Id).Max() + 1).ToString();

            var gig = new Gig
            {
                //Id = Byte.Parse(nextId),
                Artist = artist,
                DateTime = DateTime.Parse($"{model.Date}-{model.Time}"),
                Genre = genre,
                Venue = model.Venue,
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}