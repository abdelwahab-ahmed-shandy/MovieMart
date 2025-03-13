﻿using Microsoft.AspNetCore.Mvc;

namespace MovieMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ITvSeriesRepository _tvSeriesRepository;
        public CharacterController(ICharacterRepository characterRepository, IMovieRepository movieRepository, ITvSeriesRepository tvSeriesRepository)
        {
            this._characterRepository = characterRepository;
            this._tvSeriesRepository = tvSeriesRepository;
            this._movieRepository = movieRepository;
        }
        public IActionResult Index()
        {


            return View(_characterRepository.Get().ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new Character());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                _characterRepository.Create(character);
                _characterRepository.SaveDB();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var character = _characterRepository.GetOne(c => c.Id == Id);
            if (character != null)
            {
                return View(character);
            }
            return RedirectToAction("NotFound", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Character character)
        {
            if (ModelState.IsValid)
            {
                _characterRepository.Edit(character);
                _characterRepository.SaveDB();
                return RedirectToAction(nameof(Index));
            }
            return View(character);
        }

        public IActionResult Delete(int Id)
        {
            var character = _characterRepository.GetOne(c => c.Id == Id);

            if (character == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            _characterRepository.Delete(character);
            _characterRepository.SaveDB();
            return RedirectToAction(nameof(Index));
        }
    }
}
