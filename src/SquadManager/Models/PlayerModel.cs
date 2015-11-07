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
    }
}
