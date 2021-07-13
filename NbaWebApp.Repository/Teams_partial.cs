using NbaWebApp.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NbaWebApp.Repository
{
    public partial class Teams
    {
        public void Update(TeamDTO team) 
        {
            this.Id = team.Id;
            this.Name = team.Name;
        }
    }
}
