using NbaWebApp.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaWebApp.Repository
{
    public partial class Players
    {
        public void Update(PlayerDTO newPlayer)
        {
            this.Name = newPlayer.Name;
            this.Team = newPlayer.Team;
        }
    }
}
