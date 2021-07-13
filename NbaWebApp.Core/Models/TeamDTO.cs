using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbaWebApp.API.Models
{
    public class TeamDTO
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public List<PlayerDTO> Players { get; set; }
    }
}
