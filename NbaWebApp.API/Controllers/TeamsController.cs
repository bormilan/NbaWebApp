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
    public class TeamsController : Controller
    {
        private TeamsRepository _repository = null;
        public TeamsController(nba_DB dbContext)
        {
            _repository = new TeamsRepository(dbContext);
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        public IActionResult AddNewTeam()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        public ActionResult<List<TeamDTO>> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Name")] TeamDTO team)
        {
            team.Id = _repository.Add(team);
            return View("Index", _repository.GetAll());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] TeamDTO team)
        {
            if (id != team.Id)
                return BadRequest();

            var existingTeam = _repository.Get(id);
            if (existingTeam is null)
                return NotFound();

            _repository.Edit(team);

            return View("Index", _repository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            var team = _repository.Get(id);

            if (team is null)
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
