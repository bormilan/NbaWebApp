using NbaWebApp.API.Models;
using NbaWebApp.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaWebApp.Repository
{
    public class PlayersRepository
    {
        nba_DB _dbContext = null;
        public PlayersRepository(nba_DB context)
        {
            this._dbContext = context;
        }

        public List<PlayerDTO> GetAll()
        {
            return _dbContext.Players.Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Team = p.Team
            }).ToList();
        }

        public PlayerDTO Get(int? id)
        {
            return _dbContext.Players.Where(p => p.Id == id).Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Team = p.Team
            }).FirstOrDefault();
        }

        public List<PlayerDTO> Get(string name)
        {
            return _dbContext.Players.Where(p => p.Name == name).Select(p => new PlayerDTO
            {
                Id = p.Id,
                Name = p.Name,
                Team = p.Team
            }).ToList();
        }

        public int Add(PlayerDTO player)
        {
            Players newPlayer = new Players()
            {
                Name = player.Name,
                Team = player.Team
            };

            _dbContext.Players.Add(newPlayer);
            _dbContext.SaveChanges();

            return newPlayer.Id;
        }

        public void Delete(int id)
        {
            Players player = this._dbContext.Players.Where(p => p.Id == id).FirstOrDefault();
            if (player is null)
                return;

            _dbContext.Players.Remove(player);
            _dbContext.SaveChanges();
        }

        public void Edit(PlayerDTO newPlayer)
        {
            Players player = this._dbContext.Players.Where(p => p.Id == newPlayer.Id).FirstOrDefault();

            player.Update(newPlayer);
            _dbContext.SaveChanges();
        }
    }
}
