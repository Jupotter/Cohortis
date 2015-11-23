using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SquadManager.Models
{
    public class PlayerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public readonly List<BuildModel> Build = new List<BuildModel>();
        public readonly Dictionary<DayOfWeek, bool> Present = new Dictionary<DayOfWeek, bool>()
        {
            { DayOfWeek.Monday, false },
            { DayOfWeek.Tuesday, false },
            { DayOfWeek.Wednesday, false },
            { DayOfWeek.Thursday, false },
            { DayOfWeek.Friday, false },
            { DayOfWeek.Saturday, false },
            { DayOfWeek.Sunday, false },
        };
    }
}
