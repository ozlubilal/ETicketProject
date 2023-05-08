using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RouteDto:IDto
    {
        public int Id { get; set; }
        public string StartTownName { get; set; }
        public string FinishTownName { get; set; }
        public int Distance { get; set; }

    }
}
