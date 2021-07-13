using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NbaWebApp.API.Models;
using NbaWebApp.Repository;
using NbaWebApp.Repository.DataBase;

namespace NbaWebApp.API.Controllers
{
    public class PlayersController : Controller
    {
        private PlayersRepository _repository = null;
        public PlayersController(nba_DB dbContext)
        {
            _repository = new PlayersRepository(dbContext);
        }
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult AddNewPlayer()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        public ActionResult<List<PlayerDTO>> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id,[Bind("Id,Name,Team")]  PlayerDTO player)
        {
            player.Id = _repository.Add(player);
            return View("Index", _repository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Team")] PlayerDTO player)
        {
            if (id != player.Id)
                return BadRequest();

            var existingPlayer = _repository.Get(id);
            if (existingPlayer is null)
                return NotFound();

            _repository.Edit(player);

            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            var player = _repository.Get(id);

            if (player is null)
                return NotFound();

            _repository.Delete(id);

            return View("Index", _repository.GetAll());
        }

        public IActionResult Search(string Name)
        {
            return View("index", _repository.Get(Name));
        }

    }
}
