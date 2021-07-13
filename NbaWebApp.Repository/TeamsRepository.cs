using NbaWebApp.API.Models;
using NbaWebApp.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NbaWebApp.Repository
{
    public class TeamsRepository
    {
        nba_DB _dbContext = null;
        public TeamsRepository(nba_DB context)
        {
            this._dbContext = context;
        }

        public List<TeamDTO> GetAll()
        {
            return _dbContext.Teams.Select(t => new TeamDTO
            {
                Id = t.Id,
                Name = t.Name,
                Players = _dbContext.Players.Where(p => p.Team == t.Name).Select(p => new PlayerDTO { Id = p.Id, Name = p.Name, Team = p.Team }).ToList()
            }).ToList();
        }

        public TeamDTO Get(int? id)
        {
            return _dbContext.Teams.Where(t => t.Id == id).Select(t => new TeamDTO
            {
                Id = t.Id,
                Name = t.Name,
                Players = _dbContext.Players.Where(p => p.Team == t.Name).Select(p => new PlayerDTO { Id = p.Id, Name = p.Name, Team = p.Team }).ToList()
            }).FirstOrDefault();
        }

        public List<TeamDTO> Get(string name)
        {
            return _dbContext.Teams.Where(t => t.Name == name).Select(t => new TeamDTO
            {
                Id = t.Id,
                Name = t.Name,
                Players = _dbContext.Players.Where(p => p.Team == t.Name).Select(p => new PlayerDTO { Id = p.Id, Name = p.Name, Team = p.Team }).ToList()
            }).ToList();
        }

        public int Add(TeamDTO team)
        {
            Teams newTeam = new Teams()
            {
                Name = team.Name
            };

            _dbContext.Teams.Add(newTeam);
            _dbContext.SaveChanges();

            return newTeam.Id;
        }

        public void Delete(int id)
        {
            Teams team = this._dbContext.Teams.Where(t => t.Id == id).FirstOrDefault();
            if (team is null)
                return;

            _dbContext.Teams.Remove(team);
            _dbContext.SaveChanges();
        }

        public void Edit(TeamDTO newTeam)
        {
            Teams team = this._dbContext.Teams.Where(t => t.Id == newTeam.Id).FirstOrDefault();

            team.Update(newTeam);
            _dbContext.SaveChanges();
        }
    }
}
